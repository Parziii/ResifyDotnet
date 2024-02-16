using System.Text;
using Azure.Messaging.ServiceBus;
using Resify.MessageBus;
using Resify.Services.RestaurantsAPI.Models;
using Resify.Services.RestaurantsAPI.Services.Interfaces;

namespace Resify.Services.RestaurantsAPI.Messaging;

public class AzureServiceBusConsumer : IAzureServiceBusConsumer
{
	private readonly ServiceBusProcessor _authProcessor;
	private readonly IConfiguration _configuration;
	private readonly IServiceProvider _services;
	private readonly string authAPIQue;
	private readonly string serviceBusConnectionString;


	public AzureServiceBusConsumer(IConfiguration configuration, IServiceProvider services)
	{
		_configuration = configuration;

		serviceBusConnectionString = _configuration.GetValue<string>("ServiceBusConnectionString");
		authAPIQue = _configuration.GetValue<string>("TopicAndQueueNames:RestaurantRequestQueue");

		var client = new ServiceBusClient(serviceBusConnectionString);
		_authProcessor = client.CreateProcessor(authAPIQue);
		_services = services;
	}

	public async Task Start()
	{
		_authProcessor.ProcessMessageAsync += OnAuthRequestReceived;
		_authProcessor.ProcessErrorAsync += ErrorHandler;
		await _authProcessor.StartProcessingAsync();
	}

	public async Task Stop()
	{
		await _authProcessor.StopProcessingAsync();
		await _authProcessor.DisposeAsync();
	}

	private Task OnAuthRequestReceived(ProcessMessageEventArgs arg)
	{
		var message = arg.Message;
		var body = Encoding.UTF8.GetString(message.Body);
		List<FavoriteRestaurant> favoriteRestaurants = null;

		using (
			var scope = _services.CreateScope())
		{
			var serviceProvider = scope.ServiceProvider;
			var favService = serviceProvider.GetRequiredService<IFavoriteRestaurantService>();
			var messageBus = serviceProvider.GetRequiredService<IMessageBus>();

			favoriteRestaurants = favService.ReturnFavoriteRestaurants(Guid.Parse(body.Trim('"')));
			messageBus.PublishMessage(favoriteRestaurants,
				_configuration.GetValue<string>("TopicAndQueueNames:RestaurantRequestTopic"));
		}

		return Task.CompletedTask;
	}

	private Task ErrorHandler(ProcessErrorEventArgs arg)
	{
		Console.WriteLine(arg.Exception.ToString());
		return Task.CompletedTask;
	}
}
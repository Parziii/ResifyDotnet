using System.Collections.Concurrent;
using System.Text;
using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;

namespace Resify.Services.ReservationAPI.Messaging;

public class AzureServiceBusConsumer : IAzureServiceBusConsumer
{
	private readonly IConfiguration _configuration;
	private readonly string authAPIQue;
	private readonly string serviceBusConnectionString;
	private readonly ServiceBusProcessor _authProcessor;
	private readonly SemaphoreSlim _dataAvailable = new(0);
	private readonly ConcurrentBag<string> _messageData = new();
	private ServiceBusProcessor _restProcessor;

	public AzureServiceBusConsumer(IConfiguration configuration)
	{
		_configuration = configuration;

		serviceBusConnectionString = _configuration.GetValue<string>("ServiceBusConnectionString");
		authAPIQue = _configuration.GetValue<string>("TopicAndQueueNames:AuthApiQueue");

		var client = new ServiceBusClient(serviceBusConnectionString);
		_authProcessor = client.CreateProcessor(authAPIQue);
	}

	public async Task Start()
	{
		_authProcessor.ProcessMessageAsync += OnAuthRequestReceived;
		_authProcessor.ProcessErrorAsync += ErrorHandler;
	}

	public async Task Stop()
	{
		await _authProcessor.StopProcessingAsync();
		await _authProcessor.DisposeAsync();
	}

	public async Task<string> StartProcessingMessages(string topicName, string subscriptionName, Guid id)
	{
		await using var client = new ServiceBusClient(serviceBusConnectionString);
		_restProcessor = client.CreateProcessor(topicName, subscriptionName, new ServiceBusProcessorOptions());

		_restProcessor.ProcessMessageAsync += MessageHandler;
		_restProcessor.ProcessErrorAsync += ErrorHandler;

		var adminClient = new ServiceBusAdministrationClient(serviceBusConnectionString);

		var ruleName = "UserIdFilter";
		var sqlFilter = new SqlRuleFilter($"UserId = '{id.ToString()}'");

		var rules = adminClient.GetRulesAsync(topicName, subscriptionName);
		var ruleExists = false;
		await foreach (var rule in rules)
			if (rule.Name == ruleName)
			{
				ruleExists = true;
				break;
			}

		if (!ruleExists)
		{
			await adminClient.CreateRuleAsync(topicName, subscriptionName, new CreateRuleOptions(ruleName, sqlFilter));

			await adminClient.DeleteRuleAsync(topicName, subscriptionName, "$Default");
		}

		await _restProcessor.StartProcessingAsync();

		await _dataAvailable.WaitAsync();

		string result = null;

		foreach (var userId in _messageData) result = userId;

		return result;
	}

	private async Task MessageHandler(ProcessMessageEventArgs args)
	{
		var userId = Encoding.UTF8.GetString(args.Message.Body);
		_messageData.Add(userId);
		_dataAvailable.Release();
		await args.CompleteMessageAsync(args.Message);
	}

	private Task OnAuthRequestReceived(ProcessMessageEventArgs arg)
	{
		var message = arg.Message;
		var body = Encoding.UTF8.GetString(message.Body);
		return Task.CompletedTask;
	}

	private Task ErrorHandler(ProcessErrorEventArgs arg)
	{
		Console.WriteLine(arg.Exception.ToString());
		return Task.CompletedTask;
	}
}
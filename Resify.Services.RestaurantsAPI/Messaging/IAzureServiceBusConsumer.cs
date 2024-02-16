namespace Resify.Services.RestaurantsAPI.Messaging;

public interface IAzureServiceBusConsumer
{
	Task Start();
	Task Stop();
}
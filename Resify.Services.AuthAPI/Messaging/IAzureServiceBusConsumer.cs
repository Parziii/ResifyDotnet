namespace Resify.Services.ReservationAPI.Messaging;

public interface IAzureServiceBusConsumer
{
	Task Start();
	Task Stop();
	Task<string?> GetRestaurantInfo(string topicName, string subscriptionName, Guid id);
}
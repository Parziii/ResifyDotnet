namespace Resify.Services.ReservationAPI.Messaging;

public interface IAzureServiceBusConsumer
{
	Task Start();
	Task Stop();
	Task<string> StartProcessingMessages(string topicName, string subscriptionName, Guid id);
}
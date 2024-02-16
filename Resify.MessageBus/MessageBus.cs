﻿using System.Text;
using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;

namespace Resify.MessageBus;

public class MessageBus : IMessageBus
{
	private readonly string _connectionString;

	public MessageBus(string connectionString)
	{
		_connectionString = connectionString;
	}

	public async Task PublishMessage(object message, string topic_queue_Name)
	{
		await using var client = new ServiceBusClient(_connectionString);

		var sender = client.CreateSender(topic_queue_Name);

		var jsonMessage = JsonConvert.SerializeObject(message);

		var finalMessage = new ServiceBusMessage(Encoding.UTF8.GetBytes(jsonMessage))
		{
			CorrelationId = Guid.NewGuid().ToString()
		};

		await sender.SendMessageAsync(finalMessage);
		await client.DisposeAsync();
	}
}
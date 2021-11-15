// See https://aka.ms/new-console-template for more information

using Azure.Messaging.ServiceBus;

// connection string to your Service Bus namespace
var connectionString = "Endpoint=sb://standardsbtrev.servicebus.windows.net/;SharedAccessKeyName=ReadWrite;SharedAccessKey=dWC2q6d4rjRyaamLUqx9tBMnpER4qgLpUTfi8XIJFx8=;";

// name of your Service Bus queue
string queueName = "orderqueue";

// the client that owns the connection and can be used to create senders and receivers
ServiceBusClient client;

// the sender used to publish messages to the queue
ServiceBusSender sender;

client = new ServiceBusClient(connectionString);
sender = client.CreateSender(queueName);

for (int i = 0; i < 10; i++)
{
    await sender.SendMessageAsync(new ServiceBusMessage($"Message To Published Function {i}"));
}

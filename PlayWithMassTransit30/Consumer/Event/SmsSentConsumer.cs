using System;
using System.Threading.Tasks;
using MassTransit;
using PlayWithMassTransit30.Contract.Command;
using PlayWithMassTransit30.Contract.Event;

namespace PlayWithMassTransit30.Consumer.Event
{
    public class SmsSentConsumer : IConsumer<ISmsSent>
    {
        public Task Consume(ConsumeContext<ISmsSent> context)
        {
            var message = context.Message;

            Console.WriteLine($"[IConsumer<ISmsSent>] Sms sent event consumed");
            Console.WriteLine($"[IConsumer<ISmsSent>] EventId: {message.EventId}");
            Console.WriteLine($"[IConsumer<ISmsSent>] SentAtUtc: {message.SentAtUtc}");

            return Task.CompletedTask;
        }
    }
}
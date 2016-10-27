using System;
using System.Threading.Tasks;
using MassTransit;

namespace PlayWithMassTransit30.Consumer
{
    public class SendObserver : ISendObserver
    {
        public Task PreSend<T>(SendContext<T> context) where T : class
        {
            Console.WriteLine($"[ISendObserver] PreSend {context.MessageId}");
            return Task.CompletedTask;
        }

        public Task PostSend<T>(SendContext<T> context) where T : class
        {
            Console.WriteLine($"[ISendObserver] PostSend {context.MessageId}");
            return Task.CompletedTask;
        }

        public Task SendFault<T>(SendContext<T> context, Exception exception) where T : class
        {
            Console.WriteLine($"[ISendObserver] SendFault {context.MessageId}");
            return Task.CompletedTask;
        }
    }
}
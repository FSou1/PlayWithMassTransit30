using System;
using System.Threading.Tasks;
using MassTransit;
using MassTransit.Pipeline;

namespace PlayWithMassTransit30.Consumer
{
    public class ConsumeObserver : IConsumeObserver
    {
        public Task PreConsume<T>(ConsumeContext<T> context) where T : class
        {
            Console.WriteLine($"[IConsumeObserver] PreConsume {context.MessageId}");
            return Task.CompletedTask;
        }

        public Task PostConsume<T>(ConsumeContext<T> context) where T : class
        {
            Console.WriteLine($"[IConsumeObserver] PostConsume {context.MessageId}");
            return Task.CompletedTask;
        }

        public Task ConsumeFault<T>(ConsumeContext<T> context, Exception exception) where T : class
        {
            Console.WriteLine($"[IConsumeObserver] ConsumeFault {context.MessageId}");
            return Task.CompletedTask;
        }
    }
}
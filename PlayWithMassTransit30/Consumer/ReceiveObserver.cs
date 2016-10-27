using System;
using System.Threading.Tasks;
using MassTransit;

namespace PlayWithMassTransit30.Consumer
{
    public class ReceiveObserver : IReceiveObserver
    {
        public Task PreReceive(ReceiveContext context)
        {
            Console.WriteLine("[IReceiveObserver] PreReceive");
            return Task.CompletedTask;
        }

        public Task PostReceive(ReceiveContext context)
        {
            Console.WriteLine("[IReceiveObserver] PostReceive");
            return Task.CompletedTask;
        }

        public Task PostConsume<T>(ConsumeContext<T> context, TimeSpan duration, string consumerType) where T : class
        {
            Console.WriteLine($"[IReceiveObserver] PostConsume {duration} {consumerType}");
            return Task.CompletedTask;
        }

        public Task ConsumeFault<T>(ConsumeContext<T> context, TimeSpan duration, string consumerType, Exception exception) where T : class
        {
            Console.WriteLine("[IReceiveObserver] ConsumeFault");
            return Task.CompletedTask;
        }

        public Task ReceiveFault(ReceiveContext context, Exception exception)
        {
            Console.WriteLine("[IReceiveObserver] ReceiveFault");
            return Task.CompletedTask;
        }
    }
}
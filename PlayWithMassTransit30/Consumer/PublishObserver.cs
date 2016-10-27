using System;
using System.Threading.Tasks;
using MassTransit;

namespace PlayWithMassTransit30.Consumer
{
    public class PublishObserver : IPublishObserver
    {
        public Task PrePublish<T>(PublishContext<T> context) where T : class
        {
            Console.WriteLine($"[IPublishObserver] PrePublish {context.MessageId}");
            return Task.CompletedTask;
        }

        public Task PostPublish<T>(PublishContext<T> context) where T : class
        {
            Console.WriteLine($"[IPublishObserver] PostPublish {context.MessageId}");
            return Task.CompletedTask;
        }

        public Task PublishFault<T>(PublishContext<T> context, Exception exception) where T : class
        {
            Console.WriteLine($"[IPublishObserver] PublishFault {context.MessageId}");
            return Task.CompletedTask;
        }
    }
}
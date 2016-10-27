using System;
using System.Threading.Tasks;
using MassTransit;
using MassTransit.Pipeline;
using PlayWithMassTransit30.Contract.Command;

namespace PlayWithMassTransit30.Consumer
{
    public class ConsumeObserverSendSmsCommand : IConsumeMessageObserver<ISendSms<string>>
    {
        public Task PreConsume(ConsumeContext<ISendSms<string>> context)
        {
            Console.WriteLine($"[IConsumeMessageObserver<ISendSms>] PreConsume {context.MessageId}");
            return Task.CompletedTask;
        }

        public Task PostConsume(ConsumeContext<ISendSms<string>> context)
        {
            Console.WriteLine($"[IConsumeMessageObserver<ISendSms>] PostConsume {context.MessageId}");
            return Task.CompletedTask;
        }

        public Task ConsumeFault(ConsumeContext<ISendSms<string>> context, Exception exception)
        {
            Console.WriteLine($"[IConsumeMessageObserver<ISendSms>] ConsumeFault {context.MessageId}");
            return Task.CompletedTask;
        }
    }
}
using System;
using System.Threading.Tasks;
using MassTransit;
using PlayWithMassTransit30.Contract.Command;
using PlayWithMassTransit30.Extension;

namespace PlayWithMassTransit30.Consumer.Command
{
    public class SendSmsConsumer : IConsumer<ISendSms<string>>
    {
        public SendSmsConsumer(IBusControl busControl)
        {
            _busControl = busControl;
        }

        public async Task Consume(ConsumeContext<ISendSms<string>> context)
        {
            var message = context.Message;

            Console.WriteLine($"[IConsumer<ISendSms>] Send sms command consumed");
            Console.WriteLine($"[IConsumer<ISendSms>] CommandId: {message.CommandId}");
            Console.WriteLine($"[IConsumer<ISendSms>] Phone number: {message.PhoneNumber}");
            Console.WriteLine($"[IConsumer<ISendSms>] Message: {message.Message}");

            Console.Write(Environment.NewLine);
            Console.WriteLine("Публикация события: Смс сообщение отправлено");
            await _busControl.SmsSent(DateTime.UtcNow);
        }

        private readonly IBus _busControl;
    }
}
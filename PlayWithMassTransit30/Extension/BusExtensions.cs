using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MassTransit;
using PlayWithMassTransit30.Contract.Command;
using PlayWithMassTransit30.Contract.Event;

namespace PlayWithMassTransit30.Extension
{
    public static class BusExtensions
    {
        /// <summary>
        /// Отправка смс сообщения
        /// </summary>
        /// <param name="bus"></param>
        /// <param name="host"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static async Task SendSms(
            this IBus bus, Uri host, string phoneNumber, string message
        )
        {
            var command = new SendSmsCommand
            {
                CommandId = Guid.NewGuid(),
                PhoneNumber = phoneNumber,
                Message = message
            };

            await bus.SendCommand(host, command);
        }

        /// <summary>
        /// Публикация события об отправке смс сообщения
        /// </summary>
        /// <param name="bus"></param>
        /// <param name="sentAtUtc"></param>
        /// <returns></returns>
        public static async Task SmsSent(
            this IBus bus, DateTime sentAtUtc
        )
        {
            var @event = new SmsSentEvent
            {
                EventId = Guid.NewGuid(),
                SentAtUtc = sentAtUtc
            };

            await bus.PublishEvent(@event);
        }

        /// <summary>
        /// Отправка команды
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="bus"></param>
        /// <param name="address"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        private static async Task SendCommand<T>(this IBus bus, Uri address, T command) where T : class
        {
            var endpoint = await bus.GetSendEndpoint(address);
            await endpoint.Send(command);
        }

        /// <summary>
        /// Публикация события
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="bus"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private static async Task PublishEvent<T>(this IBus bus, T message) where T : class
        {
            await bus.Publish(message);
        }
    }

    class SendSmsCommand : ISendSms<string>
    {
        public Guid CommandId { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
    }

    class SmsSentEvent : ISmsSent
    {
        public Guid EventId { get; set; }
        public DateTime SentAtUtc { get; set; }
    }
}
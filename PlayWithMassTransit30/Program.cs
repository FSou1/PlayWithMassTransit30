using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Practices.Unity;
using PlayWithMassTransit30.Config;
using PlayWithMassTransit30.Contract.Command;
using PlayWithMassTransit30.Extension;

namespace PlayWithMassTransit30
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = UnityConfig.GetConfiguredContainer();

            var busControl = container.Resolve<IBusControl>();

            busControl.Start();
            
            Task.Run(async () => await SendSmsCommand(busControl));
        }

        private static async Task SendSmsCommand(IBus busControl)
        {
            Console.WriteLine("Отправка команды SendSms");

            await busControl.SendSms(AppSettings.CommandEndpoint, "89031112233", "Thank you for your reply");
            
            Console.WriteLine("Команда SendSms отправлена");
        }
    }

    public static class AppSettings
    {
        public static string HostConnString = "rabbitmq://tm:qRQ9hqhIXfOOoWYV4xXyGza5@rabbitmq-test/tm";
        public static Uri Host = new Uri(HostConnString);
        public static Uri CommandEndpoint = new Uri(HostConnString + "/play_with_masstransit_queue");
    }
}

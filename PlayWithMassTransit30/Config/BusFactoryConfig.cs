using System;
using MassTransit;
using Microsoft.Practices.Unity;
using PlayWithMassTransit30.Consumer;

namespace PlayWithMassTransit30.Config
{
    public class BusFactoryConfig
    {
        public static IBusControl GetConfiguredFactory(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            var control = Bus.Factory.CreateUsingRabbitMq(cfg => {
                var host = cfg.Host(AppSettings.Host, h => { });

                //cfg.ReceiveEndpoint(host, e=> e.LoadFrom(container));
                cfg.ReceiveEndpoint(host, "play_with_masstransit_queue", e => e.LoadFrom(container));
            });

            control.ConnectConsumeObserver(new ConsumeObserver());
            control.ConnectReceiveObserver(new ReceiveObserver());
            control.ConnectConsumeMessageObserver(new ConsumeObserverSendSmsCommand());
            control.ConnectSendObserver(new SendObserver());
            control.ConnectPublishObserver(new PublishObserver());

            return control;
        }
    }
}
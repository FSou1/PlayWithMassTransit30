using Microsoft.Practices.Unity;
using PlayWithMassTransit30.Consumer.Command;
using PlayWithMassTransit30.Consumer.Event;

namespace PlayWithMassTransit30.Config
{
    public static class UnityConfig
    {
        public static IUnityContainer GetConfiguredContainer()
        {
            var container = new UnityContainer();
            RegisterComponents(container);
            return container;
        }

        private static void RegisterComponents(IUnityContainer container)
        {
            container.RegisterType<SendSmsConsumer>(new ContainerControlledLifetimeManager());
            container.RegisterType<SmsSentConsumer>(new ContainerControlledLifetimeManager());

            container.RegisterInstance(BusFactoryConfig.GetConfiguredFactory(container));
        }
    }
}
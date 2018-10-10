using System;
using Autofac;
using NET_Autofac.Models;

namespace NET_Autofac
{
    class Program
    {
        private static IContainer container { get; set; }
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ConsoleOutput>().As<IOutput>();
            builder.RegisterType(typeof(TodayWriter)).As<IDateWriter>();
            
            builder.Register(c => new TomorrowWriter(c.Resolve<IOutput>()))
                        .AsSelf().PreserveExistingDefaults();

            builder.RegisterType(typeof(Logger)).As<ILogger>();
            builder.RegisterType<LoggerConsumer>().UsingConstructor(typeof(ILogger)).As<ILoggerConsumer>();
            container = builder.Build();
            
            Writedate();
        }
        public static void Writedate()
        {
            using(var scope = container.BeginLifetimeScope())
            {
                var writer = scope.Resolve<IDateWriter>();
                writer.WriteDate();
            }
            using(var scope = container.BeginLifetimeScope())
            {
                var writer = scope.Resolve<TomorrowWriter>();
                writer.WriteDate();
            }
            using(var scope = container.BeginLifetimeScope())
            {
                var logger = scope.Resolve<ILoggerConsumer>();
                logger.LogString("Log String test");
                logger.LogInt(33);
            }
        }
    }
}

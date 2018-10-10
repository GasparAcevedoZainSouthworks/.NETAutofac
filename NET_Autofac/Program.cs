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

            container = builder.Build();

            Writedate();
            WriteLog();
        }
        public static void Writedate()
        {
            using(var scope = container.BeginLifetimeScope())
            {
                // Testing nested scopes
                using(var scope2 = container.BeginLifetimeScope())
                {
                    var writer = scope.Resolve<IDateWriter>();
                    var writer2 = scope2.Resolve<TomorrowWriter>();

                    writer.WriteDate();
                    writer2.WriteDate();
                }
            }
        }

        public static void WriteLog()
        {
            using(var scope = container.BeginLifetimeScope(
                builder =>
                {
                    builder.RegisterType(typeof(Logger)).As<ILogger>();
                    builder.RegisterType<LoggerConsumer>().UsingConstructor(typeof(ILogger))
                        .As<ILoggerConsumer>();
                }
            ))
            {
                var logger = scope.Resolve<ILoggerConsumer>();
                logger.LogString("Log String test");
                logger.LogInt(33);
            }
        }
    }
}

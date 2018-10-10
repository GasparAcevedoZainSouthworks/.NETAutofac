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
            builder.RegisterType<TodayWriter>().As<IDateWriter>();
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
        }
    }
}

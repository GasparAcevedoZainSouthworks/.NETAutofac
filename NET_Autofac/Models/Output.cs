using System;

namespace NET_Autofac.Models
{
    public interface IOutput
    {
        void Write(string content);
    }
    public class ConsoleOutput : IOutput
    {
        public void Write(string content)
        {
            Console.WriteLine(content);
        }
    }
}
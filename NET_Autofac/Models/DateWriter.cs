using System;

namespace NET_Autofac.Models
{
    public interface IDateWriter
    {
        void WriteDate();
    }
    public class TodayWriter : IDateWriter
    {
        private IOutput output;
        public TodayWriter(IOutput output)
        {
            this.output = output;
        }
        public void WriteDate()
        {
            this.output.Write(DateTime.Today.ToShortDateString());
        }
    }
    public class TomorrowWriter : IDateWriter
    {
        private IOutput output;
        public TomorrowWriter(IOutput output)
        {
            this.output = output;
        }
        public void WriteDate()
        {
            this.output.Write(DateTime.Today.AddDays(1).ToShortDateString());
        }
    }
}
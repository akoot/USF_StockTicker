using System;
using System.Linq.Expressions;

namespace Stock_Ticker
{
    internal class CandleStick
    {
        public DateTime Date { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Open { get; set; }
        public double Close { get; set; }
        public double Volume { get; set; }

        public CandleStick(DateTime date, double open, double high, double low, double close, double volume)
        {
            this.Date = date;
            this.Open = open;
            this.High = high;
            this.Low = low;
            this.Close = close;
            this.Volume = volume;
        }

        // This was used in testing
        override public string ToString()
        {
            return $"Date: {Date}, Open/High/Low/Close/Volume: {Open}/{High}/{Low}/{Close}/{Volume}";
        }
    }
}
using System;
using System.Linq.Expressions;

namespace Stock_Ticker
{
    internal class CandleStick
    {
        private DateTime date;
        private Decimal open;
        private Decimal high;
        private Decimal low;
        private Decimal close;
        private Decimal volume;

        public CandleStick(DateTime date, Decimal open, Decimal high, Decimal low, Decimal close, Decimal volume)
        {
            this.date = date;
            this.open = open;
            this.high = high;
            this.low = low;
            this.close = close;
            this.volume = volume;
        }

        public DateTime Date { get => date; set => date = value; }
        public decimal Open { get => open; set => open = value; }
        public decimal High { get => high; set => high = value; }
        public decimal Low { get => low; set => low = value; }
        public decimal Close { get => close; set => close = value; }
        public decimal Volume { get => volume; set => volume = value; }

        override public string ToString()
        {
            return $"Date: {date}, Open/High/Low/Close/Volume: {open}/{high}/{low}/{close}/{volume}";
        }
    }
}
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

        // Create a candlestick object with all of the info from the CSV file
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

        // Function to determine the pattern
        public Pattern? GetPattern()
        {
            double bodyLength = Math.Abs(Open - Close);
            double totalLength = High - Low;
            double upperShadowLength = High - Math.Max(Open, Close);
            double lowerShadowLength = Math.Min(Open, Close) - Low;

            if (bodyLength <= totalLength * 0.1 && upperShadowLength > bodyLength && lowerShadowLength > bodyLength)
            {
                // Neutral Doji
                return Pattern.DOJI_NEUTRAL;
            }
            else if (bodyLength <= totalLength * 0.1 && upperShadowLength > bodyLength * 2 && lowerShadowLength > bodyLength * 2)
            {
                // Long-Legged Doji
                return Pattern.DOJI_LONG_LEGGED;
            }
            else if (bodyLength <= totalLength * 0.1 && upperShadowLength < bodyLength && lowerShadowLength > bodyLength)
            {
                // Gravestone Doji
                return Pattern.DOJI_GRAVESTONE;
            }
            else if (bodyLength <= totalLength * 0.1 && upperShadowLength > bodyLength && lowerShadowLength < bodyLength)
            {
                // Dragonfly Doji
                return Pattern.DOJI_DRAGONFLY;
            }
            else if (bodyLength >= totalLength * 0.9 && upperShadowLength <= bodyLength * 0.1 && lowerShadowLength <= bodyLength * 0.1)
            {
                // Marubozu pattern
                return Pattern.MARUBOZU;
            }
            else if (bodyLength <= totalLength * 0.1 && lowerShadowLength >= bodyLength * 2 && upperShadowLength <= bodyLength * 0.1)
            {
                // Hammer pattern
                return Pattern.HAMMER;
            }
            else
            {
                // Not a pattern
                return null;
            }
        }

        public 
    }
}
using System;
using System.Collections.Generic;

namespace Stock_Ticker
{
    internal class Stock
    {
        // A stock is given a time period and a list of candlesticks associated with that time period.
        private Dictionary<TimePeriod, List<CandleStick>> candleSticks;

        public Stock()
        {
            this.candleSticks = new Dictionary<TimePeriod, List<CandleStick>>();
            // For every TimePeriod enum, create a list of candlesticks for IT
            foreach (TimePeriod timePeriod in Enum.GetValues(typeof(TimePeriod)))
            {
                // Init all of the candlesticks with empty lists
                candleSticks.Add(timePeriod, new List<CandleStick>());
            }
        }

        // Unnecessary wrapping pt1
        public List<CandleStick> GetCandleSticks(TimePeriod timePeriod)
        {
            return candleSticks[timePeriod];
        }

        // Unnecessary wrapping pt2
        public void AddCandleStick(TimePeriod timePeriod, CandleStick candleStick)
        {
            candleSticks[timePeriod].Add(candleStick);
        }

    }
}
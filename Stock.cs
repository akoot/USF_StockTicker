using System;
using System.Collections.Generic;

namespace Stock_Ticker
{
    internal class Stock
    {
        private Dictionary<TimePeriod, List<CandleStick>> candleSticks;

        public Stock()
        {
            this.candleSticks = new Dictionary<TimePeriod, List<CandleStick>>();
            foreach (TimePeriod timePeriod in Enum.GetValues(typeof(TimePeriod)))
            {
                candleSticks.Add(timePeriod, new List<CandleStick>());
            }
        }

        public List<CandleStick> GetCandleSticks(TimePeriod timePeriod)
        {
            return candleSticks[timePeriod];
        }

        public void AddCandleStick(TimePeriod timePeriod, CandleStick candleStick)
        {
            candleSticks[timePeriod].Add(candleStick);
        }

    }
}
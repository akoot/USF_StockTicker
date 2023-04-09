using System.Collections.Generic;

namespace Stock_Ticker
{
    internal static class AlgorithmEnjoyer
    {
        // Function to find bullish engulfing patterns
        public static int[] FindBullishEngulfingPatterns(List<CandleStick> candlesticks)
        {
            List<int> bullishEngulfingIndices = new List<int>();

            for (int i = 1; i < candlesticks.Count; i++)
            {
                CandleStick current = candlesticks[i];
                CandleStick previous = candlesticks[i - 1];

                if (current.Open < current.Close && previous.Open > previous.Close &&
                    current.Close > previous.Open && current.Open < previous.Close &&
                    current.High > previous.High && current.Low < previous.Low)
                {
                    bullishEngulfingIndices.Add(i);
                }
            }

            return bullishEngulfingIndices.ToArray();
        }

        // Function to find bearish engulfing patterns
        public static int[] FindBearishEngulfingPatterns(List<CandleStick> candlesticks)
        {
            List<int> bearishEngulfingIndices = new List<int>();

            for (int i = 1; i < candlesticks.Count; i++)
            {
                CandleStick current = candlesticks[i];
                CandleStick previous = candlesticks[i - 1];

                if (current.Open > current.Close && previous.Open < previous.Close &&
                    current.Close < previous.Open && current.Open > previous.Close &&
                    current.High > previous.High && current.Low < previous.Low)
                {
                    bearishEngulfingIndices.Add(i);
                }
            }

            return bearishEngulfingIndices.ToArray();
        }
    }
}
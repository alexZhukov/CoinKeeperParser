using System;

namespace CoinKeeperApiClient.Helpers
{
    public static class CoinKeeperExtensions
    {
        public static DateTime TicksToDateTime(this long ticks)
        {
            return new DateTime().Add(TimeSpan.FromTicks(ticks));
        }
    }
}
using System;

namespace Dzaba.Randomizer.Utils
{
    public interface IDateTimeProvider
    {
        DateTime Now();
    }

    internal sealed class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}

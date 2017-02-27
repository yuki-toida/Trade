using System;
using Trade.Domain.ValueObjects;

namespace Trade.Domain.Services.Utilities
{
    public static class CalendarUtility
    {
        public static string GetTitle(CalendarEventType type)
        {
            switch (type)
            {
                case CalendarEventType.VolumeIncrease:
                    return TradeConsts.VolumeIncrease;

                case CalendarEventType.PriceIncrease:
                    return TradeConsts.PriceIncrease;

                case CalendarEventType.PriceDecrease:
                    return TradeConsts.PriceDecrease;

                default:
                    return string.Empty;
            }
        }
    }
}

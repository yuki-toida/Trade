using Trade.Infra.Core.Attributes;

namespace Trade.Domain.ValueObjects
{
    /// <summary>
    /// カレンダーイベントタイプ
    /// </summary>
    public enum CalendarEventType
    {
        None = 0,

        [EnumValue(TradeConsts.VolumeIncrease)]
        VolumeIncrease = 1,

        [EnumValue(TradeConsts.PriceIncrease)]
        PriceIncrease = 2,

        [EnumValue(TradeConsts.PriceDecrease)]
        PriceDecrease = 3,
    }
}

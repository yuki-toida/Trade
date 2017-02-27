namespace Trade.Domain.ValueObjects
{
    /// <summary>
    /// カレンダーイベントタイプ
    /// </summary>
    public enum CalendarEventType
    {
        None = 0,
        VolumeIncrease = 1,
        PriceIncrease = 2,
        PriceDecrease = 3,
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Trade.Domain.ValueObjects;
using Trade.Infra.Contract.Models.Dtos;
using Trade.Infra.Contract.Models.Entities;

namespace Trade.Domain.Entities.Volume
{
    public class VolumeDate
    {
        private readonly IEnumerable<YahooVolumeIncreaseRateDate> _volumeDates;

        public VolumeDate(IEnumerable<YahooVolumeIncreaseRateDate> volumeDates)
        {
            _volumeDates = volumeDates;
        }

        /// <summary>
        /// すべての日付を返却
        /// </summary>
        public DateTime[] GetAll()
        {
            return _volumeDates.Select(x => x.Date).ToArray();
        }

        /// <summary>
        /// 最も大きい日付を返却
        /// </summary>
        public DateTime GetMaxDate()
        {
            return _volumeDates.Max(x => x.Date);
        }

        /// <summary>
        /// カレンダーイベントを返却します
        /// </summary>
        public CalendarEventDto[] GetEvents()
        {
            return _volumeDates.Select(x => new CalendarEventDto()
            {
                Title = TradeConsts.VolumeIncrease,
                Start = new DateTime(x.Date.Year, x.Date.Month, x.Date.Day),
            }).ToArray();
        }
    }
}

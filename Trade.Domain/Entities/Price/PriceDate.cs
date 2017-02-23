using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Trade.Domain.ValueObjects;
using Trade.Infra.Contract.Models.Dtos;
using Trade.Infra.Contract.Models.Entities;

namespace Trade.Domain.Entities.Price
{
    public class PriceDate
    {
        private readonly IEnumerable<YahooPriceIncreaseRateDate> _priceDates;

        public PriceDate(IEnumerable<YahooPriceIncreaseRateDate> priceDates)
        {
            _priceDates = priceDates;
        }

        /// <summary>
        /// すべての日付を返却
        /// </summary>
        public DateTime[] GetAll()
        {
            return _priceDates.Select(x => x.Date).ToArray();
        }

        /// <summary>
        /// 最も大きい日付を返却
        /// </summary>
        public DateTime GetMaxDate()
        {
            return _priceDates.Max(x => x.Date);
        }

        /// <summary>
        /// カレンダーイベントを返却します
        /// </summary>
        public CalendarEventDto[] GetEvents()
        {
            return _priceDates.Select(x => new CalendarEventDto()
            {
                Title = TradeConsts.PriceIncrease,
                Start = new DateTime(x.Date.Year, x.Date.Month, x.Date.Day),
            }).ToArray();
        }
    }
}

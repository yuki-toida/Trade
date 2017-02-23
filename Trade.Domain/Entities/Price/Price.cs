using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Trade.Domain.ValueObjects;
using Trade.Infra.Contract.Models.Dtos;
using Trade.Infra.Contract.Models.Entities;
using Trade.Infra.Contract.Models.ViewModels.Price;

namespace Trade.Domain.Entities.Price
{
    public class Price
    {
        private readonly IEnumerable<YahooPriceIncreaseRate> _Prices;

        public Price(IEnumerable<YahooPriceIncreaseRate> Prices)
        {
            _Prices = Prices;
        }

        public PriceViewModel GetViewModel(DateTime targetDate, DateTime?[] allDate)
        {
            return new PriceViewModel()
            {
                Title = TradeConsts.PriceIncrease,
                TargetDate = targetDate,
                Items = _Prices.Select(xx => new PriceItemViewModel()
                {
                    Ranking = xx.Ranking,
                    Code = xx.Code,
                    Market = xx.Market,
                    Name = xx.Name,
                    Price = xx.Price,
                    IncreaseRate = xx.IncreaseRate,
                    Volume = xx.Volume,
                }).ToArray(),
                PreviousDate = allDate.OrderByDescending(x => x).FirstOrDefault(x => x < targetDate),
                NextDate = allDate.OrderBy(x => x).FirstOrDefault(x => targetDate < x),
            };
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Trade.Domain.ValueObjects;
using Trade.Infra.Contract.Models.Dtos;
using Trade.Infra.Contract.Models.Entities;
using Trade.Infra.Contract.Models.ViewModels.Volume;

namespace Trade.Domain.Entities.Volume
{
    public class Volume
    {
        private readonly IEnumerable<YahooVolumeIncreaseRate> _volumes;

        public Volume(IEnumerable<YahooVolumeIncreaseRate> volumes)
        {
            _volumes = volumes;
        }

        public VolumeViewModel GetViewModel(DateTime targetDate, DateTime?[] allDate)
        {
            return new VolumeViewModel()
            {
                Title = TradeConsts.VolumeIncrease,
                TargetDate = targetDate,
                Items = _volumes.Select(xx => new VolumeItemViewModel()
                {
                    Ranking = xx.Ranking,
                    Code = xx.Code,
                    Market = xx.Market,
                    Name = xx.Name,
                    Price = xx.Price,
                    Volume = xx.Volume,
                    VolumeAverageFive = xx.VolumeAverageFive,
                    VolumeRate = Math.Round(xx.VolumeRate, 3, MidpointRounding.AwayFromZero).ToString("F3"),
                }).ToArray(),
                PreviousDate = allDate.OrderByDescending(x => x).FirstOrDefault(x => x < targetDate),
                NextDate = allDate.OrderBy(x => x).FirstOrDefault(x => targetDate < x),
            };
        }
    }
}

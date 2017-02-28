using System;
using Trade.Infra.Contract.Entities;

namespace Trade.Domain.Entities.Volume
{
    public class VolumeIncrease
    {
        public VolumeIncrease(YahooVolumeIncreaseRate entity)
        {
            Ranking = entity.Ranking;
            Code = entity.Code;
            Market = entity.Market;
            Name = entity.Name;
            Price = entity.Price;
            Volume = entity.Volume;
            VolumeAverageFive = entity.VolumeAverageFive;
            VolumeRate = Math.Round(entity.VolumeRate, 3, MidpointRounding.AwayFromZero).ToString("F3");
        }

        public int Ranking { get; }
        public int Code { get; }
        public string Market { get; }
        public string Name { get; }
        public decimal Price { get; }
        public int Volume { get; }
        public int VolumeAverageFive { get; }
        public string VolumeRate { get; }
    }
}

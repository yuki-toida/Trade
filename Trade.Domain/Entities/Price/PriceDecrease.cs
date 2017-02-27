using Trade.Infra.Contract.Entities;

namespace Trade.Domain.Entities.Price
{
    public class PriceDecrease
    {
        public PriceDecrease(YahooPriceDecreaseRate entity)
        {
            Ranking = entity.Ranking;
            Code = entity.Code;
            Market = entity.Market;
            Name = entity.Name;
            Price = entity.Price;
            DecreaseRate = entity.DecreaseRate;
            Volume = entity.Volume;
        }

        public int Ranking { get; set; }
        public int Code { get; set; }
        public string Market { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string DecreaseRate { get; set; }
        public int Volume { get; set; }
    }
}

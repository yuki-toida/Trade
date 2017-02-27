using Trade.Infra.Contract.Entities;

namespace Trade.Domain.Entities.Price
{
    public class PriceIncrease
    {
        public PriceIncrease(YahooPriceIncreaseRate entity)
        {
            Ranking = entity.Ranking;
            Code = entity.Code;
            Market = entity.Market;
            Name = entity.Name;
            Price = entity.Price;
            IncreaseRate = entity.IncreaseRate;
            Volume = entity.Volume;
        }

        public int Ranking { get; set; }
        public int Code { get; set; }
        public string Market { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string IncreaseRate { get; set; }
        public int Volume { get; set; }
    }
}

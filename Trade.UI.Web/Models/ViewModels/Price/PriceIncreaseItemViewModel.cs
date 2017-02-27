using Trade.Domain.Entities.Price;

namespace Trade.UI.Web.Models.ViewModels.Price
{
    public class PriceIncreaseItemViewModel
    {
        public PriceIncreaseItemViewModel(PriceIncrease priceIncrease)
        {
            Ranking = priceIncrease.Ranking;
            Code = priceIncrease.Code;
            Market = priceIncrease.Market;
            Name = priceIncrease.Name;
            Price = priceIncrease.Price;
            IncreaseRate = priceIncrease.IncreaseRate;
            Volume = priceIncrease.Volume;
        }

        /// <summary>
        /// ランキング
        /// </summary>
        public int Ranking { get; set; }

        /// <summary>
        /// 銘柄コード
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 市場
        /// </summary>
        public string Market { get; set; }

        /// <summary>
        /// 銘柄名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 株価終値
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 値上がり率
        /// </summary>
        public string IncreaseRate { get; set; }

        /// <summary>
        /// 出来高
        /// </summary>
        public int Volume { get; set; }
    }
}

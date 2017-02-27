using Trade.Domain.Entities.Price;

namespace Trade.UI.Web.Models.ViewModels.Price
{
    public class PriceDecreaseItemViewModel
    {
        public PriceDecreaseItemViewModel(PriceDecrease priceDecrease)
        {
            Ranking = priceDecrease.Ranking;
            Code = priceDecrease.Code;
            Market = priceDecrease.Market;
            Name = priceDecrease.Name;
            Price = priceDecrease.Price;
            DecreaseRate = priceDecrease.DecreaseRate;
            Volume = priceDecrease.Volume;
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
        /// 値下がり率
        /// </summary>
        public string DecreaseRate { get; set; }

        /// <summary>
        /// 出来高
        /// </summary>
        public int Volume { get; set; }
    }
}

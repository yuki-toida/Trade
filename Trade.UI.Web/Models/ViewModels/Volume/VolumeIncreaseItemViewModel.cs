using Trade.Domain.Entities.Volume;

namespace Trade.UI.Web.Models.ViewModels.Volume
{
    public class VolumeIncreaseItemViewModel
    {
        public VolumeIncreaseItemViewModel(VolumeIncrease volumeIncrease)
        {
            Ranking = volumeIncrease.Ranking;
            Code = volumeIncrease.Code;
            Market = volumeIncrease.Market;
            Name = volumeIncrease.Name;
            Price = volumeIncrease.Price;
            Volume = volumeIncrease.Volume;
            VolumeAverageFive = volumeIncrease.VolumeAverageFive;
            VolumeRate = volumeIncrease.VolumeRate;
        }

        /// <summary>
        /// ランキング
        /// </summary>
        public int Ranking { get; }

        /// <summary>
        /// 銘柄コード
        /// </summary>
        public int Code { get; }

        /// <summary>
        /// 市場
        /// </summary>
        public string Market { get; }

        /// <summary>
        /// 銘柄名
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 株価終値
        /// </summary>
        public decimal Price { get; }

        /// <summary>
        /// 出来高
        /// </summary>
        public int Volume { get; }

        /// <summary>
        /// 出来高5日平均
        /// </summary>
        public int VolumeAverageFive { get; }

        /// <summary>
        /// 出来高増加率
        /// </summary>
        public string VolumeRate { get; }
    }
}

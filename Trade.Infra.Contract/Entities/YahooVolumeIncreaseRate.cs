using System;
using System.ComponentModel.DataAnnotations;

namespace Trade.Infra.Contract.Entities
{
    public class YahooVolumeIncreaseRate
    {
        /// <summary>
        /// 日付
        /// </summary>
        [Key]
        public DateTime Date { get; set; }

        /// <summary>
        /// ランキング
        /// </summary>
        [Key]
        public int Ranking { get; set; }

        /// <summary>
        /// 銘柄コード
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 取引市場
        /// </summary>
        public string Market { get; set; }

        /// <summary>
        /// 銘柄名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 株価
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 出来高
        /// </summary>
        public int Volume { get; set; }

        /// <summary>
        /// 出来高5日平均
        /// </summary>
        public int VolumeAverageFive { get; set; }

        /// <summary>
        /// 出来高増加率
        /// </summary>
        public double VolumeRate { get; set; }
    }
}

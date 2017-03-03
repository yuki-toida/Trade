using System;
using System.ComponentModel.DataAnnotations;

namespace Trade.Infra.Contract.Entities
{
    public class YahooPriceDecreaseRate
    {
        /// <summary>
        /// 日付
        /// </summary>
        [Key]
        public DateTimeOffset Date { get; set; }

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
        /// 値上がり率
        /// </summary>
        public string DecreaseRate { get; set; }

        /// <summary>
        /// 出来高
        /// </summary>
        public int Volume { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace Trade.Infra.Contract.Models.Entities
{
    public class YahooVolumeIncreaseRateDate
    {
        /// <summary>
        /// 日付
        /// </summary>
        [Key]
        public DateTime Date { get; set; }

        /// <summary>
        /// 追加時刻
        /// </summary>
        public DateTime AddDate { get; set; }

        /// <summary>
        /// 更新時刻
        /// </summary>
        public DateTime UpdtDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trade.Infra.Contract.Models.ViewModels.Shared;

namespace Trade.Infra.Contract.Models.ViewModels.Volume
{
    public class VolumeViewModel : CommonViewModel
    {
        /// <summary>
        /// 対象日付
        /// </summary>
        public DateTime TargetDate { get; set; }

        /// <summary>
        /// 出来高アイテム
        /// </summary>
        public VolumeItemViewModel[] Items { get; set; }

        /// <summary>
        /// 対象日付の一個過去日付
        /// </summary>
        public DateTime? PreviousDate { get; set; }

        /// <summary>
        /// 対象日付の一個未来日付
        /// </summary>
        public DateTime? NextDate { get; set; }
    }
}

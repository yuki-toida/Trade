using System;

namespace Trade.UI.Web.Models.ViewModels.Shared
{
    public abstract class NavigationViewModel : CommonViewModel
    {
        /// <summary>
        /// 対象日付
        /// </summary>
        public string TargetDate { get; set; }

        /// <summary>
        /// 対象日付の一個過去日付
        /// </summary>
        public DateTime? PreviousDate { get; set; }

        /// <summary>
        /// 対象日付の一個過去日付Url
        /// </summary>
        public string PreviousUrl { get; set; }

        /// <summary>
        /// 対象日付の一個未来日付
        /// </summary>
        public DateTime? NextDate { get; set; }

        /// <summary>
        /// 対象日付の一個未来日付Url
        /// </summary>
        public string NextUrl { get; set; }
    }
}

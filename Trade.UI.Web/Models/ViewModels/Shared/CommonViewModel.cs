using Trade.Domain.ValueObjects;

namespace Trade.UI.Web.Models.ViewModels.Shared
{
    public abstract class CommonViewModel
    {
        /// <summary>
        /// ページタイトル
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 現在のページのイベントタイプ
        /// </summary>
        public CalendarEventType EventType { get; set; }
    }
}

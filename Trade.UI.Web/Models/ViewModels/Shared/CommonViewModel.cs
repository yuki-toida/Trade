using Trade.Domain.Services.Utilities;
using Trade.Domain.ValueObjects;
using Trade.UI.Web.Core.Static;

namespace Trade.UI.Web.Models.ViewModels.Shared
{
    public abstract class CommonViewModel
    {
        /// <summary>
        /// 静的ファイルサーバーUrl
        /// </summary>
        public string StaticServerUrl { get; set; }

        /// <summary>
        /// ページタイトル
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 現在のページのイベントタイプ
        /// </summary>
        public CalendarEventType EventType { get; set; }

        /// <summary>
        /// ImageUrl取得
        /// </summary>
        public string GetImageUrl(string path)
        {
            return StaticUrl.GetImageUrl(StaticServerUrl, path);
        }

        /// <summary>
        /// ScriptUrl取得
        /// </summary>
        public string GetScriptUrl(string path)
        {
            return StaticUrl.GetScriptUrl(StaticServerUrl, path);
        }

        /// <summary>
        /// CssUrl取得
        /// </summary>
        public string GetCssUrl(string path)
        {
            return StaticUrl.GetCssUrl(StaticServerUrl, path);
        }

        /// <summary>
        /// LibraryUrl取得
        /// </summary>
        public string GetLibraryUrl(string path)
        {
            return StaticUrl.GetLibraryUrl(StaticServerUrl, path);
        }

        /// <summary>
        /// ナビタイトルを取得
        /// </summary>
        public string GetNaviTitle(CalendarEventType type)
        {
            return CalendarUtility.GetTitle(type);
        }
    }
}

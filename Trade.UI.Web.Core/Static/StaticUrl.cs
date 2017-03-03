using Trade.UI.Web.Core.Settings;

namespace Trade.UI.Web.Core.Static
{
    public static class StaticUrl
    {
        /// <summary>
        /// ImageUrl取得
        /// </summary>
        public static string GetImageUrl(string path)
        {
            return GetBaseUrl("images", path);
        }

        /// <summary>
        /// ScriptUrl取得
        /// </summary>
        public static string GetScriptUrl(string path)
        {
            return GetBaseUrl("scripts", path);
        }

        /// <summary>
        /// CssUrl取得
        /// </summary>
        public static string GetCssUrl(string path)
        {
            return GetBaseUrl("css", path);
        }

        /// <summary>
        /// LibraryUrl取得
        /// </summary>
        public static string GetLibraryUrl(string path)
        {
            return GetBaseUrl("lib", path);
        }

        /// <summary>
        /// 静的ファイルサーバーから静的ファイルのURLを取得
        /// </summary>
        private static string GetBaseUrl(string folder, string path)
        {
            var url = $"{AppSettings.Values.StaticServerUrl}/{folder}/{path}";

            // ブラウザキャッシュを考慮しリビジョン追加+小文字化
            return AppendRevision(url).ToLower();
        }

        /// <summary>
        /// リビジョン番号付与
        /// </summary>
        private static string AppendRevision(string url)
        {
            return $"{url}{(url.Contains("?") ? "&" : "?")}_rev={StaticRevision.Value}";
        }
    }
}

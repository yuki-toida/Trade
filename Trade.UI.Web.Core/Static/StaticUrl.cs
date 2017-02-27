namespace Trade.UI.Web.Core.Static
{
    public static class StaticUrl
    {
        /// <summary>
        /// ImageUrl取得
        /// </summary>
        public static string GetImageUrl(string serverUrl, string path)
        {
            return GetBaseUrl(serverUrl, "image", path);
        }

        /// <summary>
        /// ScriptUrl取得
        /// </summary>
        public static string GetScriptUrl(string serverUrl, string path)
        {
            return GetBaseUrl(serverUrl, "script", path);
        }

        /// <summary>
        /// CssUrl取得
        /// </summary>
        public static string GetCssUrl(string serverUrl, string path)
        {
            return GetBaseUrl(serverUrl, "css", path);
        }

        /// <summary>
        /// LibraryUrl取得
        /// </summary>
        public static string GetLibraryUrl(string serverUrl, string path)
        {
            return GetBaseUrl(serverUrl, "lib", path);
        }

        /// <summary>
        /// 静的ファイルサーバーから静的ファイルのURLを取得
        /// </summary>
        private static string GetBaseUrl(string serverUrl, string folder, string path)
        {
            var url = $"{serverUrl}/{folder}/{path}";

            // ブラウザキャッシュを考慮しリビジョン追加+小文字化
            return AppendRevision(url).ToLower();
        }

        /// <summary>
        /// リビジョン番号付与
        /// </summary>
        private static string AppendRevision(string url)
        {
            return $"{url}{(url.Contains("?") ? "&" : "?")}_rev={Revision.Value}";
        }
    }
}

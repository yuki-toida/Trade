namespace Trade.UI.Web.Core.Settings
{
    public static class AppSettings
    {
        /// <summary>
        /// 値インスタンス
        /// </summary>
        public static Value Values;

        /// <summary>
        /// 値クラスのシングルトンインスタンス作成
        /// </summary>
        public static void Create(string staticServerUrl, string googleCalendarApiKey)
        {
            if (Values != null)
                return;

            Values = Value.CreateInstance(staticServerUrl, googleCalendarApiKey);
        }

        public class Value
        {
            private Value() { }

            /// <summary>
            /// 静的ファイルサーバーUrl
            /// </summary>
            public string StaticServerUrl { get; set; }

            /// <summary>
            /// GoogleCalendarApi使用キー
            /// </summary>
            public string GoogleCalendarApiKey { get; set; }

            /// <summary>
            /// シングルトンインスタンス作成
            /// </summary>
            private static Value _instance;
            public static Value CreateInstance(string staticServerUrl, string googleCalendarApiKey)
            {
                return _instance ?? (_instance = new Value()
                       {
                           StaticServerUrl = staticServerUrl,
                           GoogleCalendarApiKey = googleCalendarApiKey
                       });
            }
        }
    }
}

using System;

namespace Trade.UI.Web.Core.Static
{
    /// <summary>
    /// 静的ファイルに付与するリビジョン番号を保持する
    /// </summary>
    public static class StaticRevision
    {
        public static string Value { get; }

        static StaticRevision()
        {
            Value = DateTime.Now.ToString("MMddHHmm"); //全APで同じとなるようMMddHHmm形式
        }
    }
}

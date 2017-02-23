using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Trade.Infra.Contract.Contexts.Application;
using Trade.UI.Batch.Abstractions;

namespace Trade.UI.Batch.Scraping.Abstractions
{
    public abstract class ScrapingBatchBase : BatchBase
    {
        protected ScrapingBatchBase(IApplicationContext appContext) : base(appContext)
        {
        }

        /// <summary>
        /// スクレイピング対象Url
        /// </summary>
        protected abstract string Url { get; }

        /// <summary>
        /// 取得したHtmlを解析する
        /// </summary>
        protected abstract BatchResultCode Scrape(HtmlDocument document);

        /// <summary>
        /// バッチ処理実行
        /// </summary>
        /// <param name="argument"></param>
        /// <returns>バッチ処理結果</returns>
        public override BatchResultCode Execute(string argument)
        {
            // Htmlを取得しHtmlDocumentにLoad
            var html = GetHtml().Result;
            var document = new HtmlDocument();
            document.LoadHtml(html);

            // Htmlを具象クラスで解析
            return Scrape(document);
        }

        /// <summary>
        /// 対象UrlのHtmlを取得する
        /// </summary>
        private async Task<string> GetHtml()
        {
            using (var httpClient = new HttpClient())
            {
                return await httpClient.GetStringAsync(Url).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// 対象の文字列から数字以外を空文字に置換します
        /// </summary>
        /// <param name="str">対象の文字列</param>
        /// <returns>数字</returns>
        protected string ReplaceNumber(string str)
        {
            var regex = new Regex(@"[^0-9]");
            return regex.Replace(str, "");
        }
    }
}

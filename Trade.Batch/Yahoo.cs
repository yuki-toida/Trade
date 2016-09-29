using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Trade.Core.Job;

namespace Trade.Batch
{
    public class Yahoo : IJob
    {
        public JobResultCode Execute(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var html = GetHtml("https://www.google.co.jp").Result;

            var document = new HtmlDocument();
            document.LoadHtml(html);

            return JobResultCode.Success;
        }

        private async Task<string> GetHtml(string uri)
        {
            using (var httpClient = new HttpClient())
            {
                return await httpClient.GetStringAsync(uri);
            }
        }
    }
}

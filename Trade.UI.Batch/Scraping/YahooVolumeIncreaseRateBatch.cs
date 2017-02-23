using System;
using System.Diagnostics;
using System.Globalization;
using HtmlAgilityPack;
using Trade.Infra.Contract.Contexts.Application;
using Trade.UI.Batch.Scraping.Abstractions;
using System.Linq;
using Trade.Infra.Contract.Models.Entities;
using Trade.Infra.Contract.Repositories;

namespace Trade.UI.Batch.Scraping
{
    public class YahooVolumeIncreaseRateBatch : ScrapingBatchBase
    {
        private readonly IRepository<YahooVolumeIncreaseRateDate> _dateRepository;
        private readonly IRepository<YahooVolumeIncreaseRate> _repository;

        public YahooVolumeIncreaseRateBatch(IApplicationContext appContext) : base(appContext)
        {
            _dateRepository = AppContext.DataContexts.YahooVolumeIncreaseRateDateRepository;
            _repository = AppContext.DataContexts.YahooVolumeIncreaseRateRepository;
        }

        protected override string Url => "http://info.finance.yahoo.co.jp/ranking/?kd=33&mk=2&tm=d&vl=b";

        protected override BatchResultCode Scrape(HtmlDocument document)
        {
            // スクレイピングデータ
            var nodeDate = document.DocumentNode.SelectSingleNode("//div[@class='dtl yjSt']");
            var nodeItems = document.DocumentNode.SelectNodes("//tr[@class='rankingTabledata yjM']");

            // 最終更新日取得
            var date = DateTime.Parse(nodeDate.InnerText.Replace("最終更新日時：", "")).Date;

            // 更新日付
            var dateEntity = _dateRepository.Find(x => x.Date == date);
            if (dateEntity == null)
            {
                // 出来高日付追加
                _dateRepository.Add(new YahooVolumeIncreaseRateDate()
                {
                    Date = date,
                    AddDate = DateTime.Now,
                    UpdtDate = DateTime.Now,
                });

                // 出来高情報追加
                foreach (var item in nodeItems)
                {
                    var childs = item.ChildNodes;
                    Add(date, childs);
                }
            }
            else
            {
                // 更新時刻更新
                dateEntity.UpdtDate = DateTime.Now;

                // 出来高情報更新
                var entities = _repository.FindBy(x => x.Date == date).ToArray();
                foreach (var item in nodeItems)
                {
                    var childs = item.ChildNodes;
                    var entity = entities.FirstOrDefault(x => x.Ranking == int.Parse(childs[0].InnerText));
                    if (entity != null)
                        Update(childs, entity);
                    else
                        Add(date, childs);
                }
            }

            AppContext.DataContexts.SaveChanges();

            return BatchResultCode.Success;
        }

        /// <summary>
        /// 追加
        /// </summary>
        private void Add(DateTime date, HtmlNodeCollection collection)
        {
            _repository.Add(new YahooVolumeIncreaseRate()
            {
                Date = date,
                Ranking = int.Parse(collection[0].InnerText),
                Code = int.Parse(collection[1].InnerText),
                Market = collection[2].InnerText,
                Name = collection[3].InnerText,
                Price = Convert.ToDecimal(collection[5].InnerText),
                Volume = int.Parse(collection[6].InnerText, NumberStyles.AllowThousands),
                VolumeAverageFive = int.Parse(collection[7].InnerText, NumberStyles.AllowThousands),
                VolumeRate = double.Parse(collection[8].InnerText.Replace("倍", "")),
            });
        }

        /// <summary>
        /// 更新
        /// </summary>
        private void Update(HtmlNodeCollection collection, YahooVolumeIncreaseRate entity)
        {
            entity.Ranking = int.Parse(collection[0].InnerText);
            entity.Code = int.Parse(collection[1].InnerText);
            entity.Market = collection[2].InnerText;
            entity.Name = collection[3].InnerText;
            entity.Price = Convert.ToDecimal(collection[5].InnerText);
            entity.Volume = int.Parse(collection[6].InnerText, NumberStyles.AllowThousands);
            entity.VolumeAverageFive = int.Parse(collection[7].InnerText, NumberStyles.AllowThousands);
            entity.VolumeRate = double.Parse(collection[8].InnerText.Replace("倍", ""));
        }
    }
}

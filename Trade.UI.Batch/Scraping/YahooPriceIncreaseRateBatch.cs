﻿using System;
using System.Globalization;
using HtmlAgilityPack;
using Trade.Infra.Contract.Contexts.Application;
using Trade.UI.Batch.Scraping.Abstractions;
using System.Linq;
using Trade.Infra.Contract.Entities;
using Trade.Infra.Contract.Repositories;
using Trade.Infra.Core.Time;

namespace Trade.UI.Batch.Scraping
{
    public class YahooPriceIncreaseRateBatch : ScrapingBatchBase
    {
        private readonly IRepository<YahooPriceIncreaseRateDate> _dateRepository;
        private readonly IRepository<YahooPriceIncreaseRate> _repository;

        public YahooPriceIncreaseRateBatch(IApplicationContext appContext) : base(appContext)
        {
            _dateRepository = AppContext.DataContexts.YahooPriceIncreaseRateDateRepository;
            _repository = AppContext.DataContexts.YahooPriceIncreaseRateRepository;
        }

        protected override string Url => "http://info.finance.yahoo.co.jp/ranking/?kd=1&tm=d&mk=1";

        protected override BatchResultCode Scrape(HtmlDocument document)
        {
            // スクレイピングデータ
            var nodeDate = document.DocumentNode.SelectSingleNode("//div[@class='dtl yjSt']");
            var nodeItems = document.DocumentNode.SelectNodes("//tr[@class='rankingTabledata yjM']");

            // 最終更新日取得
            var date = DateTimeOffset.Parse(nodeDate.InnerText.Replace("最終更新日時：", ""));
            date = new DateTimeOffset(date.Year, date.Month, date.Day, 0, 0, 0, date.Offset);

            // 更新日付
            var dateEntity = _dateRepository.Find(x => x.Date == date);
            if (dateEntity == null)
            {
                // 出来高日付追加
                _dateRepository.Add(new YahooPriceIncreaseRateDate()
                {
                    Date = date,
                    AddDate = DateTimeManager.Now,
                    UpdtDate = DateTimeManager.Now,
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
                dateEntity.UpdtDate = DateTimeManager.Now;

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
        private void Add(DateTimeOffset date, HtmlNodeCollection collection)
        {
            _repository.Add(new YahooPriceIncreaseRate()
            {
                Date = date,
                Ranking = int.Parse(collection[0].InnerText),
                Code = int.Parse(collection[1].InnerText),
                Market = collection[2].InnerText,
                Name = collection[3].InnerText,
                Price = Convert.ToDecimal(collection[5].InnerText),
                IncreaseRate = collection[6].InnerText,
                Volume = int.Parse(collection[8].InnerText, NumberStyles.AllowThousands),
            });
        }

        /// <summary>
        /// 更新
        /// </summary>
        private void Update(HtmlNodeCollection collection, YahooPriceIncreaseRate entity)
        {
            entity.Ranking = int.Parse(collection[0].InnerText);
            entity.Code = int.Parse(collection[1].InnerText);
            entity.Market = collection[2].InnerText;
            entity.Name = collection[3].InnerText;
            entity.Price = Convert.ToDecimal(collection[5].InnerText);
            entity.IncreaseRate = collection[6].InnerText;
            entity.Volume = int.Parse(collection[8].InnerText, NumberStyles.AllowThousands);
        }
    }
}

using System;
using System.Linq;
using Trade.App.Web.Services.Abstractions;
using Trade.Domain.Entities.Price;
using Trade.Infra.Contract.Contexts.Application;

namespace Trade.App.Web.Services
{
    public class PriceService : ServiceBase
    {
        public PriceService(IApplicationContext appContext) : base(appContext)
        {
        }

        /// <summary>
        /// 日付を指定して値上がり率情報と登録日付を取得
        /// </summary>
        public PriceIncreases GetIncreases(DateTime? date)
        {
            var dates = AppContext.DataContexts.YahooPriceIncreaseRateDateRepository.GetAll().Select(x => x.Date).ToArray();

            date = date ?? dates.Max(x => x);
            var allDate = dates.Select(x => x.Date).OfType<DateTime?>().ToArray();

            var entities = AppContext.DataContexts.YahooPriceIncreaseRateRepository.FindBy(x => x.Date == date);
            return new PriceIncreases(entities, date.Value, allDate);
        }

        /// <summary>
        /// 日付を指定して値下がり率情報と登録日付を取得
        /// </summary>
        public PriceDecreases GetDecreases(DateTime? date)
        {
            var dates = AppContext.DataContexts.YahooPriceDecreaseRateDateRepository.GetAll().Select(x => x.Date).ToArray();

            date = date ?? dates.Max(x => x);
            var allDate = dates.Select(x => x.Date).OfType<DateTime?>().ToArray();

            var entities = AppContext.DataContexts.YahooPriceDecreaseRateRepository.FindBy(x => x.Date == date);
            return new PriceDecreases(entities, date.Value, allDate);
        }
    }
}

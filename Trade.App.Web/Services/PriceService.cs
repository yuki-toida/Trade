using System;
using System.Linq;
using Trade.App.Web.Services.Abstractions;
using Trade.Domain.Entities;
using Trade.Domain.Entities.Price;
using Trade.Domain.Entities.Volume;
using Trade.Infra.Contract.Contexts.Application;
using Trade.Infra.Contract.Models.ViewModels.Price;
using Trade.Infra.Contract.Models.ViewModels.Volume;

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
        public PriceViewModel GetViewModel(DateTime? date)
        {
            var dateEntities = AppContext.DataContexts.YahooPriceIncreaseRateDateRepository.GetAll();
            var priceDate = new PriceDate(dateEntities);

            date = date ?? priceDate.GetMaxDate();
            var allDate = priceDate.GetAll().OfType<DateTime?>().ToArray();

            var entities = AppContext.DataContexts.YahooPriceIncreaseRateRepository.FindBy(x => x.Date == date);
            return new Price(entities).GetViewModel(date.Value, allDate);
        }
    }
}

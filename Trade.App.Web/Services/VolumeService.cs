using System;
using System.Linq;
using Trade.App.Web.Services.Abstractions;
using Trade.Domain.Entities.Volume;
using Trade.Infra.Contract.Contexts.Application;

namespace Trade.App.Web.Services
{
    public class VolumeService : ServiceBase
    {
        public VolumeService(IApplicationContext appContext) : base(appContext)
        {
        }

        /// <summary>
        /// 日付を指定して出来高情報と登録日付を取得
        /// </summary>
        public VolumeIncreases GetIncreases(DateTime? date)
        {
            var dates = AppContext.DataContexts.YahooVolumeIncreaseRateDateRepository.GetAll().Select(x => x.Date).ToArray();

            date = date ?? dates.Max(x => x);
            var allDate = dates.Select(x => x.Date).OfType<DateTime?>().ToArray();

            var entities = AppContext.DataContexts.YahooVolumeIncreaseRateRepository.FindBy(x => x.Date == date);
            return new VolumeIncreases(entities, date.Value, allDate);
        }
    }
}

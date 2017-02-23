using System;
using System.Linq;
using Trade.App.Web.Services.Abstractions;
using Trade.Domain.Entities;
using Trade.Domain.Entities.Volume;
using Trade.Infra.Contract.Contexts.Application;
using Trade.Infra.Contract.Models.ViewModels.Volume;

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
        public VolumeViewModel GetViewModel(DateTime? date)
        {
            var dateEntities = AppContext.DataContexts.YahooVolumeIncreaseRateDateRepository.GetAll();
            var volumeDate = new VolumeDate(dateEntities);

            date = date ?? volumeDate.GetMaxDate();
            var allDate = volumeDate.GetAll().OfType<DateTime?>().ToArray();

            var entities = AppContext.DataContexts.YahooVolumeIncreaseRateRepository.FindBy(x => x.Date == date);
            return new Volume(entities).GetViewModel(date.Value, allDate);
        }
    }
}

using System;
using System.Linq;
using Trade.App.Web.Services.Abstractions;
using Trade.Domain;
using Trade.Domain.Entities;
using Trade.Domain.Entities.Price;
using Trade.Domain.Entities.Volume;
using Trade.Infra.Contract.Contexts.Application;
using Trade.Infra.Contract.Models.Dtos;
using Trade.Infra.Contract.Models.ViewModels.Home;
using Trade.Infra.Core.Extensions;

namespace Trade.App.Web.Services
{
    public class HomeService : ServiceBase
    {
        public HomeService(IApplicationContext appContext) : base(appContext)
        {
        }

        public CalendarEventDto[] GetCalendarEvents(DateTime date, Func<string, string, object, string> buildUrl)
        {
            // 出来高増加率
            var volumeEntities = AppContext.DataContexts.YahooVolumeIncreaseRateDateRepository
                .FindBy(x => x.Date.Year == date.Year && x.Date.Month == date.Month)
                .ToArray();
            var volumeEvents = new VolumeDate(volumeEntities).GetEvents();
            volumeEvents.ForEach(x => x.Url = buildUrl("Index", "Volume", new {Date = x.Start}));

            // 値上がり率
            var priceEntities = AppContext.DataContexts.YahooPriceIncreaseRateDateRepository
                .FindBy(x => x.Date.Year == date.Year && x.Date.Month == date.Month)
                .ToArray();
            var priceEvents = new PriceDate(priceEntities).GetEvents();
            priceEvents.ForEach(x => x.Url = buildUrl("Index", "Price", new {Date = x.Start}));

            return volumeEvents.Concat(priceEvents).ToArray();
        }
    }
}

using System;
using System.Linq;
using System.Threading.Tasks;
using Trade.App.Web.Services.Abstractions;
using Trade.Domain.Entities.Calendar;
using Trade.Domain.Entities.Calendar.GoogleCalendar;
using Trade.Domain.ValueObjects;
using Trade.Infra.Contract.Contexts.Application;
using Trade.Infra.GoogleCalendar;

namespace Trade.App.Web.Services
{
    public class CalendarService : ServiceBase
    {
        public CalendarService(IApplicationContext appContext) : base(appContext)
        {
        }

        /// <summary>
        /// カレンダーイベント取得
        /// </summary>
        public async Task<CalendarEvent[]> GetCalendarEvents(string googleCalendarApiKey, DateTime from, DateTime to)
        {
            // 出来高増加率イベント
            var volumeIncreaseEvents = AppContext.DataContexts.YahooVolumeIncreaseRateDateRepository
                .FindBy(x => x.Date.Year == from.Year && x.Date.Month == from.Month)
                .Select(x => new CalendarEvent(x.Date, CalendarEventType.VolumeIncrease));

            // 値上がり率イベント
            var priceIncreaseEvents = AppContext.DataContexts.YahooPriceIncreaseRateDateRepository
                .FindBy(x => x.Date.Year == from.Year && x.Date.Month == from.Month)
                .Select(x => new CalendarEvent(x.Date, CalendarEventType.PriceIncrease));

            // 値下がり率イベント
            var priceDecreaseEvents = AppContext.DataContexts.YahooPriceDecreaseRateDateRepository
                .FindBy(x => x.Date.Year == from.Year && x.Date.Month == from.Month)
                .Select(x => new CalendarEvent(x.Date, CalendarEventType.PriceDecrease));

            // 祝日イベント
            var result = await new GoogleCalendarClient(googleCalendarApiKey).GetHolidays(from, to);
            var holidayEvents = AppContext.Serializer.Deserialize<GoogleCalendarHoliday>(result).Items
                .Select(x => new CalendarEvent(x.Start.Date, CalendarEventType.None, x.Summary));

            return volumeIncreaseEvents
                .Concat(priceIncreaseEvents)
                .Concat(priceDecreaseEvents)
                .Concat(holidayEvents)
                .ToArray();
        }
    }
}

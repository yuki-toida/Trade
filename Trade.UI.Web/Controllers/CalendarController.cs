using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Trade.App.Web.Services;
using Trade.Domain.ValueObjects;
using Trade.Infra.Contract.Contexts.Application;
using Trade.Infra.Core.Time;
using Trade.UI.Web.Controllers.Abstractions;
using Trade.UI.Web.Core.Settings;
using Trade.UI.Web.Models.Dtos;
using Trade.UI.Web.Models.ViewModels.Calendar;

namespace Trade.UI.Web.Controllers
{
    public class CalendarController : NavigationController
    {
        public CalendarController(IApplicationContext appContext)
            : base(appContext)
        {
        }

        public async Task<IActionResult> Index(DateTimeOffset? date)
        {
            // デフォルトは現在年月
            var now = DateTimeManager.Now;
            date = date ?? new DateTimeOffset(now.Year, now.Month, 1, 0, 0, 0, now.Offset);

            // 先月と来月
            var previousDate = date.Value.AddMonths(-1);
            var nextDate = date.Value.AddMonths(1);

            var service = new CalendarService(AppContext);

            // カレンダーイベント取得
            var events = await service.GetCalendarEvents(AppSettings.Values.GoogleCalendarApiKey, date.Value, nextDate.AddDays(-1));
            var eventDto = events.Select(x => new CalendarEventDto(x) {Url = GetEventUrl(x.Type, x.Date)});

            var model = new CalendarViewModel(date.Value, previousDate, nextDate, AppContext.Serializer.Serialize(eventDto));
            SetNavigationUrl(model);

            return View(model);
        }

        /// <summary>
        /// カレンダーイベントUrl取得
        /// </summary>
        private string GetEventUrl(CalendarEventType type, DateTimeOffset date)
        {
            switch (type)
            {
                case CalendarEventType.None:
                    return string.Empty;

                case CalendarEventType.VolumeIncrease:
                    return Url.Action("Increase", "Volume", new { Date = date });

                case CalendarEventType.PriceIncrease:
                    return Url.Action("Increase", "Price", new { Date = date });

                case CalendarEventType.PriceDecrease:
                    return Url.Action("Decrease", "Price", new { Date = date });

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

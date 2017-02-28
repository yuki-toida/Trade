using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Trade.App.Web.Services;
using Trade.Domain.ValueObjects;
using Trade.Infra.Contract.Contexts.Application;
using Trade.UI.Web.Controllers.Abstractions;
using Trade.UI.Web.Core.Settings;
using Trade.UI.Web.Models.Dtos;
using Trade.UI.Web.Models.ViewModels.Calendar;

namespace Trade.UI.Web.Controllers
{
    public class CalendarController : NavigationController
    {
        public CalendarController(IApplicationContext appContext, IOptions<AppSettings> settings)
            : base(appContext, settings)
        {
        }

        public async Task<IActionResult> Index(DateTime? date)
        {
            // デフォルトは現在年月
            var now = DateTime.Now;
            date = date ?? new DateTime(now.Year, now.Month, 1, 0, 0, 0);

            // 先月と来月
            var previousDate = date.Value.AddMonths(-1);
            var nextDate = date.Value.AddMonths(1);

            var service = new CalendarService(AppContext);

            // カレンダーイベント取得
            var events = await service.GetCalendarEvents(Settings.GoogleCalendarApiKey, date.Value, nextDate.AddDays(-1));
            var eventDto = events.Select(x => new CalendarEventDto(x) {Url = GetEventUrl(x.Type, x.Date)});

            var model = new CalendarViewModel(date.Value, previousDate, nextDate, AppContext.Serializer.Serialize(eventDto));
            SetNavigationUrl(model);

            return View(model);
        }

        /// <summary>
        /// カレンダーイベントUrl取得
        /// </summary>
        private string GetEventUrl(CalendarEventType type, DateTime date)
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

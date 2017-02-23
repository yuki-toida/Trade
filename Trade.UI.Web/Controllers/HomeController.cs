using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Trade.App.Web.Services;
using Trade.Domain.ValueObjects;
using Trade.Infra.Contract.Contexts.Application;
using Trade.Infra.Contract.Models.ViewModels.Home;
using Trade.UI.Web.Controllers.Abstractions;
using Trade.Infra.Core.Extensions;

namespace Trade.UI.Web.Controllers
{
    public class HomeController : ApplicationController
    {
        public HomeController(IApplicationContext appContext) : base(appContext)
        {
        }

        public IActionResult Index(DateTime? date)
        {
            // デフォルトは現在年月
            var now = DateTime.Now;
            date = date ?? new DateTime(now.Year, now.Month, 1, 0, 0, 0);

            // 先月と来月
            var previousDate = date.Value.AddMonths(-1);
            var nextDate = date.Value.AddMonths(1);

            // カレンダーイベント取得
            var service = new HomeService(AppContext);
            var events = service.GetCalendarEvents(date.Value, Url.Action);
            var serializedEvent = AppContext.Serializer.Serialize(events);

            var model = new HomeViewModel()
            {
                Title = TradeConsts.Home,
                Events = serializedEvent,
                Date = date.Value,
                PreviousDate = now < previousDate ? (DateTime?)null : previousDate,
                NextDate = now < nextDate ? (DateTime?)null : nextDate,
            };

            return View(model);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

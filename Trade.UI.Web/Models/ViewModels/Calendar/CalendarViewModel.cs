using System;
using Trade.Domain.ValueObjects;
using Trade.Infra.Core.Time;
using Trade.UI.Web.Models.ViewModels.Shared;

namespace Trade.UI.Web.Models.ViewModels.Calendar
{
    public class CalendarViewModel : NavigationViewModel
    {
        public CalendarViewModel(DateTimeOffset date, DateTimeOffset previousDate, DateTimeOffset nextDate, string events)
        {
            Title = TradeConsts.Calendar;
            TargetDate = date.ToString("yyyy-MM");
            PreviousDate = DateTimeManager.Now < previousDate ? (DateTimeOffset?) null : previousDate;
            NextDate = DateTimeManager.Now < nextDate ? (DateTimeOffset?) null : nextDate;
            DefaultDate = date.ToString("yyyy-MM-dd");
            Events = events;
        }

        /// <summary>
        /// フルカレンダーデフォルト日付
        /// </summary>
        public string DefaultDate { get; set; }

        /// <summary>
        /// カレンダーイベント
        /// </summary>
        public string Events { get; set; }
    }
}

using System;
using Trade.Domain.ValueObjects;
using Trade.UI.Web.Models.ViewModels.Shared;

namespace Trade.UI.Web.Models.ViewModels.Calendar
{
    public class CalendarViewModel : NavigationViewModel
    {
        public CalendarViewModel(DateTime date, DateTime previousDate, DateTime nextDate, string events)
        {
            Title = TradeConsts.Calendar;
            TargetDate = date.ToString("yyyy-MM");
            PreviousDate = DateTime.Now < previousDate ? (DateTime?) null : previousDate;
            NextDate = DateTime.Now < nextDate ? (DateTime?) null : nextDate;
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

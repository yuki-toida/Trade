using System;
using Trade.Domain.Services.Utilities;
using Trade.Domain.ValueObjects;

namespace Trade.Domain.Entities.Calendar
{
    public class CalendarEvent
    {
        public CalendarEvent(DateTime date, CalendarEventType type)
            : this(date, type, CalendarUtility.GetTitle(type))
        {
        }

        public CalendarEvent(DateTime date, CalendarEventType type, string title)
        {
            Title = title;
            Date = date;
            Type = type;
        }

        public string Title { get; }
        public CalendarEventType Type { get; }
        public DateTime Date { get; }
    }
}

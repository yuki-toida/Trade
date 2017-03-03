using System;
using Trade.Domain.ValueObjects;
using Trade.Infra.Core.Extensions;

namespace Trade.Domain.Entities.Calendar
{
    public class CalendarEvent
    {
        public CalendarEvent(DateTimeOffset date, CalendarEventType type)
            : this(date, type, type.GetValue<string>())
        {
        }

        public CalendarEvent(DateTimeOffset date, CalendarEventType type, string title)
        {
            Title = title;
            Date = date;
            Type = type;
        }

        public string Title { get; }
        public CalendarEventType Type { get; }
        public DateTimeOffset Date { get; }
    }
}

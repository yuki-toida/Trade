using System;
using Trade.Domain.Entities.Calendar;

namespace Trade.UI.Web.Models.Dtos
{
    public class CalendarEventDto
    {
        public CalendarEventDto(CalendarEvent calendarEvent)
        {
            Title = calendarEvent.Title;
            Start = calendarEvent.Date;
        }

        public string Title { get; set; }
        public DateTimeOffset Start { get; set; }
        public string Url { get; set; }
    }
}

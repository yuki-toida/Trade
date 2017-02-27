using System;

namespace Trade.Domain.Entities.Calendar.GoogleCalendar
{
    public class GoogleCalendarHoliday
    {
        public GoogleCalendarHolidayItem[] Items { get; set; }
    }

    public class GoogleCalendarHolidayItem
    {
        public string Summary { get; set; }
        public GoogleCalendarHolidayDate Start { get; set; }
        public GoogleCalendarHolidayDate End { get; set; }
    }

    public class GoogleCalendarHolidayDate
    {
        public DateTime Date { get; set; }
    }
}

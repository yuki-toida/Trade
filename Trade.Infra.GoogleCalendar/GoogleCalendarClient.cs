using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Trade.Infra.GoogleCalendar
{
    public class GoogleCalendarClient
    {
        private const string ApiUrlBase = "https://www.googleapis.com/calendar/v3/calendars";
        private const string CalendarId = "japanese__ja@holiday.calendar.google.com";
        private const int MaxHolidaysCount = 31;

        private readonly string _apiKey;

        public GoogleCalendarClient(string apiKey)
        {
            _apiKey = apiKey;
        }

        /// <summary>
        /// 指定期間内の祝日を取得します
        /// </summary>
        public async Task<string> GetHolidays(DateTimeOffset from, DateTimeOffset to)
        {
            var timeMin = from.ToString("yyyy-MM-dd") + "T00%3A00%3A00.000Z";
            var timeMax = to.ToString("yyyy-MM-dd") + "T00%3A00%3A00.000Z";
            var url = $"{ApiUrlBase}/{CalendarId}/events?key={_apiKey}&timeMin={timeMin}&timeMax={timeMax}&maxResults={MaxHolidaysCount}&orderBy=startTime&singleEvents=true";

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url).ConfigureAwait(false);
                if (!response.IsSuccessStatusCode)
                    throw new HttpRequestException($"GoogleCalendarApi:{response.StatusCode}:{url}");

                return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
        }
    }
}

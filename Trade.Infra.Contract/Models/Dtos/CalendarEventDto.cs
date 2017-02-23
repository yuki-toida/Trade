using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trade.Infra.Contract.Models.Dtos
{
    public class CalendarEventDto
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public DateTime Start { get; set; }
    }
}

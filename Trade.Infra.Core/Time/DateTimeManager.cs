using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trade.Infra.Core.Time
{
    public static class DateTimeManager
    {
        public static DateTimeOffset Now => DateTimeOffset.Now;
    }
}

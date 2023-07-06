using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketApplication.Constants;

namespace MarketApplication.Helpers
{
    public static class TimeHelper
    {
        public static DateTime GetCurrentTime()
        {
            var currentTime = DateTime.UtcNow;

            currentTime.AddHours(TimeConstants.UTF);

            return currentTime;
        }
    }
}

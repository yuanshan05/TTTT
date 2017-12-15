using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPro.Exstensions
{
    public static class DateTimeExstension
    {
        public static long ConvertLong(this DateTime date)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            TimeSpan toNow = date.Subtract(dtStart);
            long timeStamp = toNow.Ticks;
            timeStamp = long.Parse(timeStamp.ToString().Substring(0, timeStamp.ToString().Length - 4));
            return timeStamp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="Exception">long 转 DateTime失败</exception>
        /// <returns></returns>
        public static DateTime ConvertLongDateTime(long value)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            if (long.TryParse(value + "0000", out long timelong))
            {
                TimeSpan toNow = new TimeSpan(timelong);
                DateTime dtResult = dtStart.Add(toNow);
                return dtResult;
            }
            else
                throw new Exception("转换失败");

        }
    }
}

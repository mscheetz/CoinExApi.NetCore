using CoinExApiAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinExApiAccess.Core
{
    public class Helper
    {
        /// <summary>
        /// Create new decmial to the Nth power
        /// </summary>
        /// <param name="precision">precision of decimal</param>
        /// <param name="value">Value to set, default = 1</param>
        /// <returns>New decimal</returns>
        public decimal DecimalValueAtPrecision(int precision, int value = 1)
        {
            var pow = Math.Pow(10, precision);
            decimal newValue = value / (decimal)pow;

            return newValue;
        }

        /// <summary>
        /// Get string value of interval for api calls
        /// </summary>
        /// <param name="interval">Interval value</param>
        /// <returns>String of interval</returns>
        public string IntervalToString(Interval interval)
        {
            switch(interval)
            {
                case Interval.OneM:
                    return "1min";
                case Interval.ThreeM:
                    return "3min";
                case Interval.FiveM:
                    return "5min";
                case Interval.FifteenM:
                    return "15min";
                case Interval.ThirtyM:
                    return "30min";
                case Interval.OneH:
                    return "1hour";
                case Interval.TwoH:
                    return "2hour";
                case Interval.FourH:
                    return "4hour";
                case Interval.SixH:
                    return "6hour";
                case Interval.TwelveH:
                    return "12Hour";
                case Interval.OneD:
                    return "1day";
                case Interval.ThreeD:
                    return "3day";
                case Interval.OneW:
                    return "1week";
                default:
                    return "1min";
            }
        }
    }
}

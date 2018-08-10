using CoinExApiAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        /// Convert an object to a string of property names and values
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="myObject">Object to convert</param>
        /// <returns>String of properties and values</returns>
        public string ObjectToString<T>(T myObject)
        {
            var qsValues = string.Empty;

            foreach (PropertyInfo p in myObject.GetType().GetProperties())
            {
                qsValues += qsValues != string.Empty ? "&" : "";
                qsValues += $"{p.Name}={p.GetValue(myObject, null)}";
            }

            return qsValues;
        }

        /// <summary>
        /// Convert a Dictionary to a string of property names and values
        /// </summary>
        /// <param name="myDictionary">Object to convert</param>
        /// <returns>String of properties and values</returns>
        public string DictionaryToString(SortedDictionary<string, string> myDictionary)
        {
            var qsValues = string.Empty;

            foreach(var item in myDictionary)
            {
                qsValues += qsValues != string.Empty ? "&" : "";
                qsValues += $"{item.Key}={item.Value}";
            }

            return qsValues;
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

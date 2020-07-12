using System;
using System.ComponentModel;
using System.Globalization;

namespace FuhoCommerce.Application.Common.Extensions
{
    public static class Extensions
    {
        public static T ConvertTo<T>(this string input)
        {
            try
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));
                return (T)converter.ConvertFromString(input);
            }
            catch (NotSupportedException)
            {
                return default;
            }
        }


        public static long ToLong(this double value)
        {
            return value.ToString(CultureInfo.InvariantCulture).ConvertTo<long>();
        }

        public static int ToInt(this Enum value)
        {
            return Convert.ToInt32(value);
        }
    }
}

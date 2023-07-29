using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public static class Utility
    {
        public static string GetDisplayName<T>(this T enumValue) where T : IComparable, IFormattable, IConvertible // C# 7.3+: where T : struct, Enum
        {

            DisplayAttribute displayAttribute = (DisplayAttribute)enumValue.GetType()
                                                         .GetMember(enumValue.ToString())
                                                         .First()
                                                         .GetCustomAttributes(typeof(DisplayAttribute), false).First();

            string displayName = displayAttribute?.GetName();

            return displayName ?? enumValue.ToString();
        }
    }
}

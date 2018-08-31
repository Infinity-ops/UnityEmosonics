using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    internal static class Extensions
    {
        public static String EnumToString(this Enum value)
        {
            return Enum.GetName(value.GetType(), value);
        }
    }
}

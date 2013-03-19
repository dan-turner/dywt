using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dywt.Web
{
    public static class BoolExtensions
    {
        public static string ToYesNo(this bool value)
        {
            return value ? "Yes" : "No";
        }

        public static string ToLabels(this bool value, string trueLabel, string falseLabel)
        {
            return value ? trueLabel : falseLabel;
        }

        public static string ToLabels(this bool? value, string trueLabel, string falseLabel, string nullLabel)
        {
            return !value.HasValue ? nullLabel : value.Value.ToLabels(trueLabel, falseLabel);
        }
    }
}
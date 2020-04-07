using System;
using System.Globalization;

namespace CalculadoraDeDespesas.Utils
{
    public static class Extensions
    {
        public static bool CanBeParsedToANumber(this string str)
        {
            if (!string.IsNullOrWhiteSpace(str))
                return double.TryParse(str, out double result);
            else
                return false;
        }

        public static string ParseNumberToBrazilianCurrencyFormat(this double str)
        {
            return $"R$ {str.ToString("F2", CultureInfo.CurrentCulture)}";
        }
    }
}

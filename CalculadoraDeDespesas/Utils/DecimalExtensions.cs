﻿using System.Globalization;

namespace CalculadoraDeDespesas.Utils
{
    public static class DecimalExtensions
    {
        public static string ParseNumberToBrazilianCurrencyFormat(this decimal value) => $"R$ {value.ToString("F2", CultureInfo.CurrentCulture)}";
    }
}

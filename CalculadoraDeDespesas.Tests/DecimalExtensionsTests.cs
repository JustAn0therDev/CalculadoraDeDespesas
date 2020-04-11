using CalculadoraDeDespesas.Utils;
using Xunit;

namespace CalculadoraDeDespesas.Tests
{
    public class DecimalExtensionsTests
    {
        [Theory]
        [InlineData(4)]
        [InlineData(10)]
        [InlineData(123)]
        [InlineData(900)]
        [InlineData(39)]
        [InlineData(3200)]
        [InlineData(1273892.29302)]
        public void ShouldReturnValueFormattedToBrazilianCurrency(decimal valueToParseAsBrazilianCurrency)
        {
            string actualFormattedString = valueToParseAsBrazilianCurrency.ParseNumberToBrazilianCurrencyFormat();
            string expectedString = $"R$ {valueToParseAsBrazilianCurrency:F2}";
            Assert.Equal(expectedString, actualFormattedString);
        }
    }
}

using Xunit;

namespace CalculadoraDeDespesas.Tests
{
    public class SpendingsCalculatorTests
    {
        private ICalculator _spendingsCalculator = new SpendingsCalculator();

        [Fact]
        public void CalculateFixedSpendingsButWeCanAlreadyPayIt()
        {
            decimal sumOfTotalIncomes = _spendingsCalculator.TotalOfFixedSpendings;
            decimal result = _spendingsCalculator.CalculateFixedSpendings(sumOfTotalIncomes);
            Assert.Equal(0M, result);
        }

        [Fact]
        public void CalculateVariableSpendingsButFixedSpendingsWasNotCalculated()
        {
            decimal sumOfTotalIncomes = 3000M;
            decimal result = _spendingsCalculator.CalculateVariableSpendings(sumOfTotalIncomes);
            Assert.Equal(_spendingsCalculator.TotalOfVariableSpendings, result);
        }

        [Fact]
        public void CalculateVariableSpendingsShouldReturnZero()
        {
            decimal extraIncome = 900;
            decimal sumOfAllIncomesBiggerThanSpendings = _spendingsCalculator.TotalOfAllSpendings + extraIncome;
            decimal result = _spendingsCalculator.CalculateVariableSpendings(sumOfAllIncomesBiggerThanSpendings);
            Assert.Equal(0, result);
        }

        [Fact]
        public void CalculateFixedSpendingsShouldReturnZero()
        {
            decimal extraIncome = 900;
            decimal sumOfAllIncomesBiggerThanSpendings = _spendingsCalculator.TotalOfFixedSpendings + extraIncome;
            decimal result = _spendingsCalculator.CalculateFixedSpendings(sumOfAllIncomesBiggerThanSpendings);
            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData(3500)]
        [InlineData(2000)]
        [InlineData(100)]
        [InlineData(2402)]
        [InlineData(-2304)]
        [InlineData(-5000)]
        public void CalculateFixedSpendingsShouldReturnDifference(decimal income)
        {
            decimal expectedDifferenceOfValues = income - _spendingsCalculator.TotalOfFixedSpendings;
            decimal result = _spendingsCalculator.CalculateFixedSpendings(income);
            Assert.Equal(expectedDifferenceOfValues, result);
        }

        [Theory]
        [InlineData(3900)]
        [InlineData(4200)]
        [InlineData(4100)]
        [InlineData(4000)]
        [InlineData(4500)]
        public void CalculateVariableSpendingsShouldReturnDifference(decimal income)
        {
            decimal expectedDifferenceOfValues = (income - _spendingsCalculator.TotalOfFixedSpendings) - _spendingsCalculator.TotalOfVariableSpendings;
            decimal result = _spendingsCalculator.CalculateVariableSpendings(income);
            Assert.Equal(expectedDifferenceOfValues, result);
        }
    }
}

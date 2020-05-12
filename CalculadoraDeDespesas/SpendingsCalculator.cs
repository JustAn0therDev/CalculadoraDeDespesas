namespace CalculadoraDeDespesas
{
    public class SpendingsCalculator : ICalculator
    {
        public decimal TotalOfFixedSpendings => 3895.53M;
        public decimal TotalOfVariableSpendings => 800M;
        public decimal TotalOfAllSpendings => TotalOfFixedSpendings + TotalOfVariableSpendings;

        public decimal CalculateFixedSpendings(decimal sumOfAllIncomes)
        {
            if (WeCanAlreadyPayFixedSpendings(sumOfAllIncomes))
                return 0;
            return sumOfAllIncomes - TotalOfFixedSpendings;
        }

        private bool WeCanAlreadyPayFixedSpendings(decimal sumOfAllIncomes)
        {
            bool stillValueLeftAfterPayingFixedSpendings = sumOfAllIncomes - TotalOfFixedSpendings >= 0;
            return stillValueLeftAfterPayingFixedSpendings;
        }

        public decimal CalculateVariableSpendings(decimal sumOfAllIncomes)
        {
            if (WeCanAlreadyPayVariableSpendings(sumOfAllIncomes))
                return 0;
            if (!WeCanAlreadyPayFixedSpendings(sumOfAllIncomes))
                return TotalOfVariableSpendings;
            return (sumOfAllIncomes - TotalOfFixedSpendings) - TotalOfVariableSpendings;
        }

        private bool WeCanAlreadyPayVariableSpendings(decimal sumOfAllIncomes)
        {
            bool stillValueLeftAfterPayingVariableSpendings = (sumOfAllIncomes - TotalOfFixedSpendings) - TotalOfVariableSpendings >= 0;
            return stillValueLeftAfterPayingVariableSpendings;
        }
    }
}
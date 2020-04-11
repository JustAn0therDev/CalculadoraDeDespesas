namespace CalculadoraDeDespesas
{
    public class SpendingsCalculator : ICalculator
    {
        public decimal TotalOfFixedSpendings => 3895.53M;
        public decimal TotalOfVariableSpendings => 800M;
        public decimal TotalOfAllSpendings => TotalOfFixedSpendings + TotalOfVariableSpendings;

        public decimal CalculateFixedSpendings(decimal sumOfAllIncomes)
        {
            if (CanWeAlreadyPayFixedSpendings(sumOfAllIncomes))
                return 0;
            return sumOfAllIncomes - TotalOfFixedSpendings;
        }

        private bool CanWeAlreadyPayFixedSpendings(decimal sumOfAllIncomes)
        {
            bool stillValueLeftAfterPayingFixedSpendings = sumOfAllIncomes - TotalOfFixedSpendings >= 0;
            return stillValueLeftAfterPayingFixedSpendings;
        }

        public decimal CalculateVariableSpendings(decimal sumOfAllIncomes)
        {
            if (CanWeAlreadyPayVariableSpendings(sumOfAllIncomes))
                return 0;
            if (!CanWeAlreadyPayFixedSpendings(sumOfAllIncomes))
                return TotalOfVariableSpendings;
            return (sumOfAllIncomes - TotalOfFixedSpendings) - TotalOfVariableSpendings;
        }

        private bool CanWeAlreadyPayVariableSpendings(decimal sumOfAllIncomes)
        {
            bool stillValueLeftAfterPayingVariableSpendings = (sumOfAllIncomes - TotalOfFixedSpendings) - TotalOfVariableSpendings >= 0;
            return stillValueLeftAfterPayingVariableSpendings;
        }
    }
}
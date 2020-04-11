namespace CalculadoraDeDespesas
{
    public class SpendingsCalculator
    {
        private decimal TotalOfFixedSpendings { get; set; }
        private decimal TotalOfVariableSpendings { get; set; }

        public SpendingsCalculator(decimal totalOfFixedSpendings, decimal totalOfVariableSpendings)
        {
            TotalOfFixedSpendings = totalOfFixedSpendings;
            TotalOfVariableSpendings = totalOfVariableSpendings;
        }

        public decimal CalculateFixedSpendings(decimal sumOfAllIncomes)
        {
            decimal result = sumOfAllIncomes - TotalOfFixedSpendings;

            if (WeCanAlreadyPayTheSpendings(result) || HasAlreadyCalculatedFixedSpendings(sumOfAllIncomes))
                return 0.0M;

            return result;
        }

        public decimal CalculateVariableSpendings(decimal sumOfAllIncomes)
        {
            if (HasAlreadyCalculatedVariableSpendings(sumOfAllIncomes))
                return 0.0M;

            if (!HasAlreadyCalculatedFixedSpendings(sumOfAllIncomes))
                return TotalOfVariableSpendings;

            decimal result = (sumOfAllIncomes - TotalOfFixedSpendings) - TotalOfVariableSpendings;

            return result;
        }

        private bool HasAlreadyCalculatedFixedSpendings(decimal sumOfAllIncomes)
            => sumOfAllIncomes - TotalOfFixedSpendings >= 0;

        private bool HasAlreadyCalculatedVariableSpendings(decimal sumOfAllIncomes)
            => (sumOfAllIncomes - TotalOfFixedSpendings) - TotalOfVariableSpendings >= 0;

        private bool WeCanAlreadyPayTheSpendings(decimal spendingValue) 
            => spendingValue == 0;
    }
}
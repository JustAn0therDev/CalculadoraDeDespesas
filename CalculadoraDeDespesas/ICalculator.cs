namespace CalculadoraDeDespesas
{
    public interface ICalculator
    {
        decimal TotalOfFixedSpendings { get; }
        decimal TotalOfVariableSpendings { get; }
        decimal TotalOfAllSpendings { get; }
        decimal CalculateFixedSpendings(decimal sumOfAllIncomes);
        decimal CalculateVariableSpendings(decimal sumOfAllIncomes);
    }
}
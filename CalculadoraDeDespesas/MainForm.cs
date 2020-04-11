using CalculadoraDeDespesas.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraDeDespesas
{
    public partial class MainForm : Form
    {

        private readonly ICalculator _spendingsCalculator;

        private decimal _momTotalIncome { get; set; }
        private decimal _dadTotalIncome { get; set; }
        private decimal _myTotalIncome { get; set; }

        private decimal MomTotalIncome
        {
            get => _momTotalIncome;
            set
            {
                _momTotalIncome = value;
                CalculateSpendingOnAnyIncomeValueChange();
            }
        }
        private decimal DadTotalIncome
        {
            get => _dadTotalIncome;
            set
            {
                _dadTotalIncome = value;
                CalculateSpendingOnAnyIncomeValueChange();
            }
        }
        private decimal MyTotalIncome
        {
            get => _myTotalIncome;
            set
            {
                _myTotalIncome = value;
                CalculateSpendingOnAnyIncomeValueChange();
            }
        }

        private decimal CalculatedFixedSpendings
            => _spendingsCalculator.CalculateFixedSpendings(SumOfAllIncomes);

        private decimal CalculatedVariableSpendings
            => _spendingsCalculator.CalculateVariableSpendings(SumOfAllIncomes);

        private decimal SumOfAllIncomes
            => new List<decimal> { MomTotalIncome, DadTotalIncome, MyTotalIncome }.Sum(income => income);

        public MainForm()
        {
            _spendingsCalculator = new SpendingsCalculator();

            InitializeComponent();
            ShowAllConstantSpendingsOnForm();
        }

        private void ShowAllConstantSpendingsOnForm()
        {
            TotalOfFixedSpendingsTextBox.Text = _spendingsCalculator.TotalOfFixedSpendings.ParseNumberToBrazilianCurrencyFormat();
            TotalOfVariableSpendingsTextBox.Text = _spendingsCalculator.TotalOfVariableSpendings.ParseNumberToBrazilianCurrencyFormat();
            TotalSpendings.Text = _spendingsCalculator.TotalOfAllSpendings.ParseNumberToBrazilianCurrencyFormat();
        }

        private void CalculateSpendingOnAnyIncomeValueChange()
        {
            try
            {
                UpdateIncomeAndCalculatedSpendingsOnScreen();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK);
            }
        }

        private void UpdateIncomeAndCalculatedSpendingsOnScreen()
        {
            TotalOfFixedSpendingsTextBox.Text = CalculatedFixedSpendings.ParseNumberToBrazilianCurrencyFormat();
            TotalOfVariableSpendingsTextBox.Text = CalculatedVariableSpendings.ParseNumberToBrazilianCurrencyFormat();
            TotalIncome.Text = SumOfAllIncomes.ParseNumberToBrazilianCurrencyFormat();
        }

        private async void AlmiraTextBox_TextChanged(object sender, EventArgs e)
            => MomTotalIncome = await ConvertTextBoxValueToDecimal(sender);

        private async void CarlosTextBox_TextChanged(object sender, EventArgs e)
            => DadTotalIncome = await ConvertTextBoxValueToDecimal(sender);

        private async void RuanTextBox_TextChanged(object sender, EventArgs e)
            => MyTotalIncome = await ConvertTextBoxValueToDecimal(sender);

        private Task<decimal> ConvertTextBoxValueToDecimal(object sender)
        {
            string incomeAsString = (sender as TextBox).Text;
            decimal.TryParse(incomeAsString, out decimal incomeParsedToDecimal);
            return Task.FromResult(incomeParsedToDecimal);
        }
    }
}

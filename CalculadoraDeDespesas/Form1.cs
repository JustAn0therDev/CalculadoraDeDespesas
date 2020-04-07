using CalculadoraDeDespesas.Utils;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraDeDespesas
{
    public partial class Form1 : Form
    {
        #region Private Properties
        private const double TotalOfFixedSpendings = 3895.53;
        private const double TotalOfVariableSpendings = 800;
        private const double TotalOfAllSpendings = TotalOfFixedSpendings + TotalOfVariableSpendings;

        private double _momTotalIncome { get; set; }
        private double _dadTotalIncome { get; set; }
        private double _myTotalIncome { get; set; }

        private double MomTotalIncome
        {
            get
            {
                return _momTotalIncome;
            }
            set
            {
                _momTotalIncome = value;
                CalculateSpendingOnAnyIncomeValueChange();
            }
        }
        private double DadTotalIncome
        {
            get
            {
                return _dadTotalIncome;
            }
            set
            {
                _dadTotalIncome = value;
                CalculateSpendingOnAnyIncomeValueChange();
            }
        }
        private double MyTotalIncome
        {
            get
            {
                return _myTotalIncome;
            }
            set
            {
                _myTotalIncome = value;
                CalculateSpendingOnAnyIncomeValueChange();
            }
        }

        private double CalculatedFixedSpendings
        {
            get
            {
                return CalculateFixedSpendings();
            }
        }

        private double CalculatedVariableSpendings
        {
            get
            {
                return CalculateVariableSpendings();
            }
        }

        private double SumOfAllIncomes
        {
            get
            {
                return CalculateSumOfIncomes();
            }
        }

        #endregion

        #region Constructors

        public Form1()
        {
            InitializeComponent();
            TotalOfFixedSpendingsTextBox.Text = TotalOfFixedSpendings.ParseNumberToBrazilianCurrencyFormat();
            TotalOfVariableSpendingsTextBox.Text = TotalOfVariableSpendings.ParseNumberToBrazilianCurrencyFormat();
            TotalSpendings.Text = TotalOfAllSpendings.ParseNumberToBrazilianCurrencyFormat();
        }

        #endregion

        #region Private Methods

        private void CalculateSpendingOnAnyIncomeValueChange()
        {
            try
            {
                TotalOfFixedSpendingsTextBox.Text = CalculatedFixedSpendings.ParseNumberToBrazilianCurrencyFormat();
                TotalOfVariableSpendingsTextBox.Text = CalculatedVariableSpendings.ParseNumberToBrazilianCurrencyFormat();
                TotalIncome.Text = SumOfAllIncomes.ParseNumberToBrazilianCurrencyFormat();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ocorreu um erro na aplicação. Erro: {ex.Message}",
                    "Erro",
                    MessageBoxButtons.OK
                    );
            }
        }

        private double CalculateFixedSpendings()
        {
            double result = SumOfAllIncomes - TotalOfFixedSpendings;

            if (WeCanAlreadyPayTheSpendings(result) || HasAlreadyCalculatedFixedSpendings())
                return 0.0;

            return result;
        }

        private double CalculateVariableSpendings()
        {
            if (HasAlreadyCalculatedVariableSpendings())
                return 0.0;

            if (!HasAlreadyCalculatedFixedSpendings())
                return TotalOfVariableSpendings;

            double result = (SumOfAllIncomes - TotalOfFixedSpendings) - TotalOfVariableSpendings;

            return result;
        }

        private bool HasAlreadyCalculatedFixedSpendings()
        {
            return SumOfAllIncomes - TotalOfFixedSpendings >= 0;
        }

        private bool HasAlreadyCalculatedVariableSpendings()
        {
            return (SumOfAllIncomes - TotalOfFixedSpendings) - TotalOfVariableSpendings >= 0;
        }

        private bool WeCanAlreadyPayTheSpendings(double spendingValue)
        {
            return spendingValue == 0;
        }

        private double CalculateSumOfIncomes()
        {
            return (MomTotalIncome + DadTotalIncome + MyTotalIncome);
        }

        private async void AlmiraTextBox_TextChanged(object sender, EventArgs e)
        {
            MomTotalIncome = await ConvertTextBoxValueToNumber(sender);
        }

        private async void CarlosTextBox_TextChanged(object sender, EventArgs e)
        {
            DadTotalIncome = await ConvertTextBoxValueToNumber(sender);
        }

        private async void RuanTextBox_TextChanged(object sender, EventArgs e)
        {
            MyTotalIncome = await ConvertTextBoxValueToNumber(sender);
        }

        private Task<double> ConvertTextBoxValueToNumber(object sender)
        {
            double incomeParsedToDouble = 0;
            string incomeAsString = (sender as TextBox).Text;

            if (incomeAsString.CanBeParsedToANumber())
                incomeParsedToDouble = Convert.ToDouble(incomeAsString);

            return Task.FromResult(incomeParsedToDouble);
        }

        #endregion
    }
}

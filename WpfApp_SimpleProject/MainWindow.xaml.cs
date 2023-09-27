using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp_SimpleProject.Commons;

namespace WpfApp_SimpleProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CurrencyConverter _currencyConverter;
        public MainWindow()
        {
            _currencyConverter = new CurrencyConverter();
            InitializeComponent();


            if(_currencyConverter.Currencies != null)
            {
                foreach(var currency in _currencyConverter.Currencies)
                {
                    ComboBox_Currency.Items.Add(currency.cc);
                }
            }
        }

        private void MenuItem_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string selectedCurrency = ComboBox_Currency.SelectedItem as string;
            double amount;

            if (double.TryParse(TextBox_Amount.Text, out amount))
            {
                double convertedAmount = ConvertCurrency(selectedCurrency, amount);
                Label_StatusStripItem.Content = $"{amount} {selectedCurrency} = {convertedAmount} UAH";
            }
            else
            {
                Label_StatusStripItem.Content = "Invalid amount entered.";
            }
        }

        private double ConvertCurrency(string targetCurrency, double amount)
        {
            if (_currencyConverter.Currencies != null)
            {
                foreach (var currency in _currencyConverter.Currencies)
                {
                    if (currency.cc == targetCurrency)
                    {
                        return amount * currency.rate;
                    }
                }
            }
            return 0.0;
        }
    }
}

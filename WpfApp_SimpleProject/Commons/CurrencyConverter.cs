using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Collections.ObjectModel;

namespace WpfApp_SimpleProject.Commons
{
    public class CurrencyConverter//буде хранити силку наших валют та самі валюти
    {
        //20200302&json
        private string _href = "https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?date=";
        private string _fullHref = String.Empty;
        private DateTime _date;
        public ObservableCollection<Currency> Currencies { get; private set; }

        public CurrencyConverter()//собираємо конструктор та получати текущую дату
        {
            Date = DateTime.Now;
        }

        public DateTime Date
        {
            get { return _date; }

            set
            {   
                _date = value;
                _fullHref = _href + _date.ToString("yyyyMMdd") + "&json";
                LoadCurrencies();
            }
        }
        public string BankHrefApi//публічне свойство яке => допоможе получити доступ до цієї силки
        {
            get
            {
                return _fullHref;
            }
        }
        private void LoadCurrencies()
        {
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            string currenciesJSONResponse = client.DownloadString(_fullHref);

            Console.WriteLine(currenciesJSONResponse);
        }
    }
}

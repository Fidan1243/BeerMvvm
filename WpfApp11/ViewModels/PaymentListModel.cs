using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp11.Commands;
using WpfApp11.Models;
using WpfApp11.Views;

namespace WpfApp11.ViewModels
{
    public class PaymentListModel : BaseViewModel
    {
        public RelayCommand CloseCommand { get; set; }

        public List<Payment> BeerList { get; set; }

        public PaymentView CheckView { get; set; }
        public Window1 MainWindow { get; set; }
        public PaymentListModel()
        {
            CloseCommand = new RelayCommand((e) => {

                CheckView.Close();
                MainWindow.Show();

            });
        }
    }
}

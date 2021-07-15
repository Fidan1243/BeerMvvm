using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp11.Commands;
using WpfApp11.Models;
using WpfApp11.Repository;
using WpfApp11.Views;

namespace WpfApp11.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        int index = 0;
        public Window1 MainWindow { get; set; }
        public BeerRepo BeerRepo { get; set; }
        private ObservableCollection<Beer> ResBeers { get; set; }
        public ObservableCollection<Beer> Beers { get; set; }
        public List<Payment> Beers1 { get; set; } = new List<Payment>();

        private Beer beer;

        public Beer Beer
        {
            get { return beer; }
            set { beer = value; OnPropertyChanged(); }
        }

        public RelayCommand SelectedItemChangedCommand { get; set; }
        public RelayCommand HistoryCommand { get; set; }
        public RelayCommand PlusCommand { get; set; }
        public RelayCommand MinusCommand { get; set; }
        public RelayCommand BuyCommand { get; set; }
        public RelayCommand ResetCommand { get; set; }

        public PaymentListModel Model { get; set; }

        public MainViewModel()
        {
            BeerRepo = new BeerRepo();
            Beers = new ObservableCollection<Beer>(BeerRepo.GetAll());
            ResBeers = new ObservableCollection<Beer>(BeerRepo.GetAll());
            Beer = Beers[0];

            SelectedItemChangedCommand = new RelayCommand((SelectedItem) =>
            {
                var item = SelectedItem as Beer;
                Beer = item;
                
            });

            BuyCommand = new RelayCommand((e) =>
            {
                Payment py = new Payment
                {
                    BeerName = Beer.Name,
                    Count = Beer.Count,
                    Date = DateTime.Now,
                    TotalPrice = Beer.Count * Beer.Price
                };
                Beers.First((e1) => e1.Name == Beer.Name).Stock -= Beers.First((e1) => e1.Name == Beer.Name).Count;
                Beers1.Add(py);
            });
            ResetCommand = new RelayCommand((e) =>
            {
                Beers = ResBeers;
                Beer = Beers[0];
                Beers1.Clear();
            });

            MinusCommand = new RelayCommand((e) =>
            {
                Beer.Count -= 1;
            },
            (e1) => {
                if (Beer.Count > 1)
                {
                    return true;
                }
                return false;
            }
            );

            PlusCommand = new RelayCommand((e) =>
            {
                Beer.Count += 1;
            },
            (e1) =>
            {
                if (Beer.Count < Beer.Stock)
                {
                    return true;
                }
                return false;
            });

            HistoryCommand = new RelayCommand((e) =>
            {

                var view = new PaymentView();
                Model = new PaymentListModel();
                Model.MainWindow = MainWindow;
                Model.BeerList = Beers1;
                Model.CheckView = view;
                view.DataContext = Model;

                MainWindow.Hide();
                view.ShowDialog();


            });


        }






    }
}

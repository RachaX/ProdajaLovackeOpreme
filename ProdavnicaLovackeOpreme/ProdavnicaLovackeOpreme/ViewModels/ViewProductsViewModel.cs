using Microsoft.Extensions.DependencyInjection;
using ProdavnicaLovackeOpreme.Commands;
using ProdavnicaLovackeOpreme.Services;
using ProdavnicaLovackeOpreme.Util;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace ProdavnicaLovackeOpreme.ViewModels
{
    public class ViewProductsViewModel : ViewModelBase
    {
        private IServiceProvider _serviceProvider;
        private ComboBoxItem? _category;
        private ComboBoxItem? _storage;
        private bool _isSalesman;

        public ComboBoxItem? Category
        {
            get { return _category; }
            set { _category = value; OnPropertyChanged(nameof(Category)); }
        }

        public ComboBoxItem? Storage
        {
            get { return _storage; }
            set { _storage = value; OnPropertyChanged(nameof(Storage)); }
        }

        public bool IsSalesman
        {
            get { return _isSalesman; }
            set 
            { 
                _isSalesman = value;
                OnPropertyChanged(nameof(IsSalesman)); 
            }
        }

        public ObservableCollection<ComboBoxItem> Categories { get; set; }
        public ObservableCollection<ComboBoxItem> Storages { get; set; }
        public ObservableCollection<ProductItem> Products { get; set; }

        public RelayCommand SearchCommand { get; set; }
        public RelayCommand CreateBillCommand { get; set; }
        public ViewProductsViewModel(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
            var service = _serviceProvider.GetRequiredService<SalesmanService>();
            var user = _serviceProvider.GetRequiredService<Storage>().User;
            if (user!.Type.Equals("Salesman"))
                IsSalesman = true;
            else
                IsSalesman = false;

            setFilters();

            Products = new ObservableCollection<ProductItem>(service.filterProducts(Category.Content.ToString(), Storage.Content.ToString()));

            SearchCommand = new RelayCommand(o =>
            {
                Products.Clear();
                var list = new ObservableCollection<ProductItem>(service.filterProducts(Category.Content.ToString(), Storage.Content.ToString()));
                foreach (var item in list)
                {
                    Products.Add(item);
                }
            }, o => true);

            CreateBillCommand = new RelayCommand(o =>
            {
                _serviceProvider.GetRequiredService<Storage>().BillItems = new List<ProductItem>();

                var cmbs = _serviceProvider.GetRequiredService<CustomMessageBoxService>();

                for (int i = 0; i < Products.Count; i++)
                {
                    if (Products[i].IsSelected == true)
                    {
                        _serviceProvider.GetRequiredService<Storage>().BillItems.Add(Products[i]);
                        Products[i].IsSelected = false;
                    }
                }

                if(_serviceProvider.GetRequiredService<Storage>().BillItems.Count == 0)
                {
                    cmbs.Show("errorTitle", "emptyBill", MessageBoxButton.OK);
                }
                else
                {
                    cmbs.Show("successTitle", "productsAddedToBill", MessageBoxButton.OK);
                }

            }, o => true);

        }

        public void setFilters()
        {
            var service = _serviceProvider.GetRequiredService<SalesmanService>();

            List<string> storages = service.loadStorages();

            Categories = new ObservableCollection<ComboBoxItem>
            {
                new ComboBoxItem { Content = (string) Application.Current.Resources["allCategories"]},
                new ComboBoxItem { Content = (string) Application.Current.Resources["rifleCategory"]},
                new ComboBoxItem { Content = (string) Application.Current.Resources["pistolCategory"]},
                new ComboBoxItem { Content = (string) Application.Current.Resources["opticCategory"]},
                new ComboBoxItem { Content = (string) Application.Current.Resources["ammoCategory"]},
                new ComboBoxItem { Content = (string) Application.Current.Resources["wearCategory"]}
            };

            Category = Categories[0];

            Storages = new ObservableCollection<ComboBoxItem>();
            Storages.Add(new ComboBoxItem { Content = (string)Application.Current.Resources["allStorages"] });

            Storage = Storages[0];

            for (int i = 0; i < storages.Count; i++)
            {
                Storages.Add(new ComboBoxItem { Content = storages[i] });
            }
        }


    }
}

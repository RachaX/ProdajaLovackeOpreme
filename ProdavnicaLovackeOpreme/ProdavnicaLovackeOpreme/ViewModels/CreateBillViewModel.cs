using Microsoft.Extensions.DependencyInjection;
using ProdavnicaLovackeOpreme.Commands;
using ProdavnicaLovackeOpreme.Services;
using ProdavnicaLovackeOpreme.Util;
using System.Collections.ObjectModel;

namespace ProdavnicaLovackeOpreme.ViewModels
{
    public class CreateBillViewModel : ViewModelBase
    {
        private IServiceProvider _serviceProvider;
        private double _price;
        
        public double Price
        {
            get { return _price; }
            set
            {
                _price = value;              
                OnPropertyChanged(nameof(Price));
            }
        }

        public RelayCommand PrintBillCommand { get; set; }
        public static ObservableCollection<Util.BillItem> BillItems { get; set; }


        public CreateBillViewModel(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
            showItems();

            PrintBillCommand = new RelayCommand(o =>
            {
                var service = _serviceProvider.GetRequiredService<SalesmanService>();
                var cmbs = _serviceProvider.GetRequiredService<CustomMessageBoxService>();
                if(service.createBill(new List<Util.BillItem>(BillItems)))
                {
                    cmbs.Show("errorTitle", "billCreated", System.Windows.MessageBoxButton.OK);
                    BillItems.Clear();
                }
                else
                {
                    cmbs.Show("errorTitle", "quantityError" , System.Windows.MessageBoxButton.OK);
                }

            }, o => true);
        }

        public void showItems()
        {
            List<ProductItem> products = _serviceProvider.GetRequiredService<Services.Storage>().BillItems;
            BillItems = new ObservableCollection<Util.BillItem>();

            if (products != null && products.Count > 0)
            {
                foreach (ProductItem product in products)
                {
                    var billItem = new Util.BillItem
                    {
                        Name = product.Name,
                        Price = product.Price,
                        Quantity = "1",
                        ProductId = product.Id,
                        StorageId = (int)product.StorageId,
                    };

                    billItem.PropertyChanged += BillItem_PropertyChanged;

                    BillItems.Add(billItem);
                }

                calculateTotal();
            }
        }

        private void BillItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(BillItem.Quantity))
            {
                calculateTotal(); 
            }
        }

        public void calculateTotal()
        {
            double sum = 0;
            foreach(var item in BillItems)
            {
                if(double.TryParse(item.Price, out double price) && (int.TryParse(item.Quantity, out int quantity)))
                {
                    sum += price * quantity;
                }
                else
                {
                    var cmbs = _serviceProvider.GetRequiredService<CustomMessageBoxService>();
                    cmbs.Show("errorTitle", "quantityIsNaN", System.Windows.MessageBoxButton.OK);
                }
            }
            Price = sum;
        }
    }
}

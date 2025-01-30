using Microsoft.Extensions.DependencyInjection;
using ProdavnicaLovackeOpreme.Commands;
using ProdavnicaLovackeOpreme.Models;
using ProdavnicaLovackeOpreme.Services;
using ProdavnicaLovackeOpreme.Util;
using System.Collections.ObjectModel;

namespace ProdavnicaLovackeOpreme.ViewModels
{
    public class OfferViewModel : ViewModelBase
    {
        private IServiceProvider _serviceProvider;
        private List<Product> _myProducts;

        public ObservableCollection<Util.OfferItem> Products { get; set; }
        public List<Product> MyProducts { get => _myProducts; set { _myProducts = value; } }
        public RelayCommand CreateOfferCommand { get; set; }
        public OfferViewModel(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;        

            CreateOfferCommand = new RelayCommand(o =>
            {
                var cmbs = _serviceProvider.GetRequiredService<CustomMessageBoxService>();
                List<Util.OfferItem> offerItems = Products.Where(item => item.IsSelected == true).ToList();

                if (offerItems.Count > 0)
                {
                    var service = _serviceProvider.GetRequiredService<SupplierService>();

                    var quantity = offerItems.Any(offer => offer.Quantity == 0 || offer.Quantity < 0);
                    if (quantity)
                    {
                        cmbs.Show("errorTitle", "quantityZero", System.Windows.MessageBoxButton.OK);
                    }
                    else
                    {
                        service.createOffer(offerItems);
                        cmbs.Show("successTitle", "offerCreated", System.Windows.MessageBoxButton.OK);
                    }
                }
                else
                {
                    cmbs.Show("errorTitle", "chooseAtLeastOneProduct", System.Windows.MessageBoxButton.OK);
                }

            }, o => true);
        }

        public void loadMyProducts()
        {
            MyProducts = _serviceProvider.GetRequiredService<SupplierService>().getSupplierProducts();
        }

        public void showOfferItems()
        {
            loadMyProducts();
            var service = _serviceProvider.GetRequiredService<SupplierService>();
            List<Product> myProducts = service.getSupplierProducts();

            Products = new ObservableCollection<Util.OfferItem>();

            for(int i = 0; i < myProducts.Count; i++)
            {
                Products.Add(new Util.OfferItem
                {
                    Id = myProducts[i].ProductId,
                    Name = myProducts[i].Name,
                    Category = myProducts[i].CategoryCategoryName,
                    Price = myProducts[i].Price.ToString(),
                    IsSelected = false,
                    Quantity = 0
                });
            }
        }

        
    }
}

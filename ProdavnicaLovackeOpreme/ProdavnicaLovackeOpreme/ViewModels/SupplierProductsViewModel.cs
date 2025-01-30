using Microsoft.Extensions.DependencyInjection;
using ProdavnicaLovackeOpreme.Models;
using ProdavnicaLovackeOpreme.Services;
using ProdavnicaLovackeOpreme.Util;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Controls;
using Storage = ProdavnicaLovackeOpreme.Services.Storage;
using System.Windows;
using System;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ProdavnicaLovackeOpreme.ViewModels
{
    public class SupplierProductsViewModel : ViewModelBase
    {
        private IServiceProvider _serviceProvider;
        private string _supplierName;

        public string SupplierName
        {
            get { return _supplierName; }
            set { _supplierName = value; OnPropertyChanged(nameof(SupplierName));  }
        }
        public ObservableCollection<ProductItem> Products { get; set; }

        public SupplierProductsViewModel(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            showProducts();
        }

        public void showProducts()
        {
            var service = _serviceProvider.GetRequiredService<SupplierService>();
            User? user = _serviceProvider.GetRequiredService<Storage>().User;

            SupplierName = user.CompanyName + " " + (string)Application.Current.Resources["productsOwner"];

            Products = new ObservableCollection<ProductItem>();

            List<Product> products = service.getSupplierProducts();

            for (int i = 0; i < products.Count; i++)
            {
                Products.Add(new ProductItem
                {
                    Id = i,
                    Name = products[i].Name,
                    Description = products[i].Description,
                    Price = products[i].Price.ToString(),
                    Category = products[i].CategoryCategoryName,
                    Image = ByteArrayToImage(products[i].Image),
                    IsVisible = false,
                });
            }
        }

        private ImageSource ByteArrayToImage(byte[] byteArray) 
        { 
            using (MemoryStream ms = new MemoryStream(byteArray)) 
            { 
                BitmapImage bitmap = new BitmapImage(); 
                bitmap.BeginInit(); bitmap.StreamSource = ms; 
                bitmap.CacheOption = BitmapCacheOption.OnLoad; 
                bitmap.EndInit(); 
                return bitmap; 
            } 
        }
    }
}

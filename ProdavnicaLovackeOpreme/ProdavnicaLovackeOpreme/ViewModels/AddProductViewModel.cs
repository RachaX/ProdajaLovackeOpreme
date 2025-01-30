using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;
using ProdavnicaLovackeOpreme.Commands;
using ProdavnicaLovackeOpreme.Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace ProdavnicaLovackeOpreme.ViewModels
{
    public class AddProductViewModel : ViewModelBase
    {
        private IServiceProvider _serviceProvider;
        private string _productName;
        private string _productDescription;
        private string _productPrice;
        private ComboBoxItem? _productCategory;
        private String _productImage;

        public ObservableCollection<ComboBoxItem> Categories { get; set; }
        public RelayCommand ChooseImageCommand { get; set; }
        public RelayCommand AddProductCommand { get; set; }

        public string ProductName
        {
            get { return _productName ?? string.Empty; }
            set { _productName = value;  OnPropertyChanged(nameof(ProductName)); }
        }

        public string ProductDescription
        {
            get { return _productDescription ?? string.Empty; }
            set { _productDescription = value; OnPropertyChanged(nameof(ProductDescription)); }
        }

        public string ProductPrice
        {
            get { return _productPrice ?? string.Empty; }
            set { _productPrice = value; OnPropertyChanged(nameof(ProductPrice)); }
        }

        public ComboBoxItem? ProductCategory
        {
            get { return _productCategory ?? new ComboBoxItem { Content = string.Empty }; }
            set { _productCategory = value; OnPropertyChanged(nameof(ProductCategory)); }
        }
         
        public String ProductImage
        {
            get { return _productImage ?? string.Empty; }
            set { _productImage = value; OnPropertyChanged(nameof(ProductImage)); }
        }

        public AddProductViewModel(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
            Categories = new ObservableCollection<ComboBoxItem>
            {
                new ComboBoxItem { Content = (string) Application.Current.Resources["rifleCategory"]},
                new ComboBoxItem { Content = (string) Application.Current.Resources["pistolCategory"]},
                new ComboBoxItem { Content = (string) Application.Current.Resources["opticCategory"]},
                new ComboBoxItem { Content = (string) Application.Current.Resources["ammoCategory"]},
                new ComboBoxItem { Content = (string) Application.Current.Resources["wearCategory"]}
            };

            ChooseImageCommand = new RelayCommand(o =>
            {
                var openFileDialog = new OpenFileDialog
                {
                    Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
                    Title = (string)Application.Current.Resources["selectImage"]
                };

                if (openFileDialog.ShowDialog() == true)
                {
                    ProductImage = openFileDialog.FileName;
                }
            }, o => true);

            AddProductCommand = new RelayCommand(o =>
            {
                var cmbs = _serviceProvider.GetRequiredService<CustomMessageBoxService>();
                var productService = _serviceProvider.GetRequiredService<SupplierService>();

                if(!string.IsNullOrEmpty(ProductName) && !string.IsNullOrEmpty(ProductDescription) && !string.IsNullOrEmpty(ProductPrice) && !string.IsNullOrEmpty(ProductCategory.Content.ToString()) && !string.IsNullOrEmpty(ProductImage))
                {
                    string[] priceElements = ProductPrice.Split("."); 
                    if (double.TryParse(ProductPrice, out double price) && priceElements.Length == 1)
                    {
                        productService.addProduct(ProductName, price, ProductCategory.Content.ToString(), ProductDescription, ProductImage);
                        cmbs.Show("successTitle", "successfullyAddedProduct" , MessageBoxButton.OK);
                        ProductName = string.Empty;
                        ProductDescription = string.Empty;
                        ProductPrice = string.Empty;
                        ProductImage = string.Empty;
                        ProductCategory.Content = new ComboBoxItem { Content = string.Empty };
                    }
                    else
                    {
                        cmbs.Show("errorTitle", "priceError" , MessageBoxButton.OK);
                    }
                }
                else
                {
                    cmbs.Show("errorTitle", "allFieldsRequired", MessageBoxButton.OK);
                }
            }, o => true);
        }
    }
}

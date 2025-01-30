using ProdavnicaLovackeOpreme.Models;
using ProdavnicaLovackeOpreme.Util;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using Microsoft.Extensions.DependencyInjection;
using ProdavnicaLovackeOpreme.ViewModels;

namespace ProdavnicaLovackeOpreme.Services
{
    public class SalesmanService : BaseService
    {
        public SalesmanService() 
        { }

        public List<string> loadStorages()
        {
            List<Models.Storage> storages = _context.Storages.ToList();
            List<string> list = new List<string>();
            for (int i = 0; i < storages.Count; i++)
            {
                list.Add(storages[i].Name);
            }
            return list;
        }

        public List<ProductItem> filterProducts(string category, string storage)
        {
            List<ProductItem> filteredList = new List<ProductItem>();
            List<StorageItem> storageItems = _context.StorageItems.ToList();
            List<Models.Storage> storages = _context.Storages.ToList();
            List<Product> products = _context.Products.ToList();
            bool salesman = App._servicesProvider.GetRequiredService<Services.Storage>().User.Type.Equals("Salesman");
            bool manager = App._servicesProvider.GetRequiredService<Services.Storage>().User.Type.Equals("Manager");

            List<Product> filterProducts = new List<Product>();

            if (category.Equals("Puška"))
                category = "Rifle";
            else if (category.Equals("Pištolj"))
                category = "Pistol";
            else if (category.Equals("Municija"))
                category = "Ammunition";
            else if (category.Equals("Optika"))
                category = "Optic";
            else if (category.Equals("Odjeća"))
                category = "Wear";

            if((category.Equals("All categories") || category.Equals("Sve kategorije")) && (storage.Equals("All storages") || storage.Equals("Svi magacini")))
            {
                filterProducts = products.Where(product => storageItems.Any(item => product.ProductId == item.ProductProductId)).ToList();
            } 
            else if(category.Equals("All categories") || category.Equals("Sve kategorije"))
            {
                Console.WriteLine("Magacin trazis jedan");
                storageItems = storageItems.Where(item => storages.Any(store => store.Name.Equals(storage) && item.StorageStorageId == store.StorageId)).ToList();
                filterProducts = products.Where(product => storageItems.Any(items => items.ProductProductId == product.ProductId)).ToList();
            } 
            else if(storage.Equals("All storages") || storage.Equals("Svi magacini"))
            {
                Console.WriteLine("Po kategoriji filtriranje");
                products = products.Where(product => product.CategoryCategoryName.Equals(category)).ToList();   
                filterProducts = products.Where(product => storageItems.Any(item => item.ProductProductId == product.ProductId)).ToList();
            } 
            else
            {
                Console.WriteLine("Filtiranje pravo");
                products = products.Where(product => product.CategoryCategoryName.Equals(category)).ToList();
                storageItems = storageItems.Where(item => storages.Any(store => store.Name.Equals(storage) && item.StorageStorageId == store.StorageId)).ToList();
                filterProducts = products.Where(product => storageItems.Any(item => item.ProductProductId == product.ProductId)).ToList();
            }


            for (int i = 0; i < filterProducts.Count; i++)
            {
                var allStorageItems = _context.StorageItems.ToList();
                var listOfProducts = new List<StorageItem>();

                if (!storage.Equals("All storages") || !storage.Equals("Svi magacini"))
                {
                    listOfProducts = storageItems.Where(item => item.ProductProductId == filterProducts[i].ProductId).ToList();
                }
                else
                {
                    listOfProducts = allStorageItems.Where(item => item.ProductProductId == filterProducts[i].ProductId).ToList();
                }

                for (int j = 0; j < listOfProducts.Count; j++)
                {
                    int storageID = listOfProducts[j].StorageStorageId;
                    int productID = filterProducts[i].ProductId;
                    int index = filteredList.Count;

                    filteredList.Add(new ProductItem
                    {
                        Id = filterProducts[i].ProductId,
                        Name = filterProducts[i].Name,
                        Description = filterProducts[i].Description,
                        Price = filterProducts[i].Price.ToString(),
                        Category = filterProducts[i].CategoryCategoryName,
                        Image = ByteArrayToImage(filterProducts[i].Image),
                        IsSelected = false,
                        IsVisibleLocation = salesman || manager,
                        IsVisible = salesman,
                        AllowedCommand = manager,
                        StorageId = listOfProducts[j].StorageStorageId,
                        StorageName = _context.Storages.Where(storage => storage.StorageId == listOfProducts[j].StorageStorageId).ToList()[0].Location,
                        DeleteProductCommand = new Commands.RelayCommand(o =>
                        {
                            App._servicesProvider.GetRequiredService<ManagerService>().deleteProduct(productID, storageID);
                            App._servicesProvider.GetRequiredService<ViewProductsViewModel>().Products.RemoveAt(index);
                        }, o => true)
                    });
                }
            }
            return filteredList;
        }

        public bool createBill(List<Util.BillItem> items)
        {
            foreach (var item in items)
            {
                var storageItem = _context.StorageItems.FirstOrDefault(storageItem => storageItem.ProductProductId == item.ProductId && storageItem.StorageStorageId == item.StorageId);
                if (storageItem == null)
                    return false;

                if (storageItem.Quantity < int.Parse(item.Quantity) || int.Parse(item.Quantity) == 0)
                    return false;
                else
                {
                    storageItem.Quantity -= int.Parse(item.Quantity);
                }

            }
            _context.SaveChanges();

            var bill = new Bill { UserUserId = App._servicesProvider.GetRequiredService<Storage>().User.UserId, Date = DateOnly.FromDateTime(DateTime.Now) };
            _context.Bills.Add(bill);
            _context.SaveChanges();

            var groupedItems = items.GroupBy(item => item.ProductId).Select(group => new
            {
                ProductId = group.Key,
                Quantity = group.Sum(item => int.Parse(item.Quantity))
            }).ToList();

            foreach (var billItem  in groupedItems)
            {
                _context.BillItems.Add(new Models.BillItem { BillBillId = bill.BillId, ProductProductId = billItem.ProductId, Quantity = billItem.Quantity });
            }
            _context.SaveChanges();
            return true;
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

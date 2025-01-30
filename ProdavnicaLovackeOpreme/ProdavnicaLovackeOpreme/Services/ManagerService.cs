using Microsoft.Extensions.DependencyInjection;
using ProdavnicaLovackeOpreme.Models;
using ProdavnicaLovackeOpreme.Util;
using ProdavnicaLovackeOpreme.ViewModels;
using System.Collections.ObjectModel;

namespace ProdavnicaLovackeOpreme.Services
{
    public class ManagerService : BaseService
    {
        public ManagerService() { }

        public ObservableCollection<Employer> loadEmployers(String type)
        {
            ObservableCollection<Employer> list = new ObservableCollection<Employer>();
            List<User> users = new List<User>();

            if(type.Equals("All employers") || type.Equals("Svi zaposleni"))
            {
                users = _context.Users.Where(emp => !emp.Type.Equals("Manager")).ToList();
            }
            else if(type.Equals("Active") || type.Equals("Aktivni"))
            {
                users = _context.Users.Where(emp => emp.Logged == (sbyte)1).ToList();
            }
            else if(type.Equals("Offline") || type.Equals("Odjavljeni"))
            {
                users = _context.Users.Where(emp => emp.Logged == (sbyte)0).ToList();
            }

            foreach(var user in users)
            {
                Employer em;
                if (user.Type.Equals("Supplier"))
                {
                    em = new Employer
                    {
                        Name = user.CompanyName,
                        Surname = user.Jib,
                        Type = (string)App.Current.Resources[user.Type],
                        Logged = user.Logged == 0 ? false : true,
                    };
                }
                else
                {
                    em = new Employer
                    {
                        Name = user.Name,
                        Surname = user.Surname,
                        Type = (string)App.Current.Resources[user.Type],
                        Logged = user.Logged == 0? false : true,
                    };
                }

                if (em.Logged == true)
                    em.LoggedStatus = (string)App.Current.Resources["activeEmployer"];
                else
                    em.LoggedStatus = (string)App.Current.Resources["inactiveEmployer"];
                list.Add(em);
            }
            return list;
        }

        public List<ReportItem> getReportItems(string type)
        {
            List<ReportItem> list = new List<ReportItem>();
            var bills = _context.Bills.Where(bill => bill.ReportReportId == null).ToList();
            DateOnly today = DateOnly.FromDateTime(DateTime.Today);

            if (type.Equals("Dnevni") || type.Equals("Daily"))
            {
                bills = bills.Where(bill => bill.Date == today).ToList();
            }
            else if(type.Equals("Sedmični") || type.Equals("Weekly"))
            {
                DateOnly sevenDaysAgo = today.AddDays(-7);
                bills = bills.Where(bill => bill.Date >= sevenDaysAgo && bill.Date <= today).ToList();
            }
            else if(type.Equals("Mjesečni") || type.Equals("Monthly"))
            {
                DateOnly monthAgo = today.AddMonths(-1);
                bills = bills.Where(bill => bill.Date >= monthAgo && bill.Date <= today).ToList();
            }

            foreach (var bill in bills)
            {
                var billItems = _context.BillItems.Where(billItem => billItem.BillBillId == bill.BillId).ToList();

                foreach(var billItem in billItems)
                {
                    Product p = _context.Products.FirstOrDefault(product => product.ProductId == billItem.ProductProductId);
                    list.Add(new ReportItem
                    {
                        Name = p.Name,
                        Quantity = billItem.Quantity,
                        Price = (double)p.Price,
                        Date = bill.Date,
                        BillId = bill.BillId,
                        ProductId = p.ProductId,
                    });
                }
            }

            List<ReportItem> groupedItems = list.GroupBy(product => new {product.ProductId, product.Date}).Select(group => new ReportItem
            {
                ProductId = group.Key.ProductId,
                BillId = group.First().BillId,
                Quantity = group.Sum(product => product.Quantity),
                Name = group.First().Name,
                Price = group.Sum(product => product.Price),
                Date = group.Key.Date
            }).ToList();

            return groupedItems;
        }

        public bool createReport(ObservableCollection<ReportItem> items, string type)
        {
            switch(type)
            {
                case "Dnevni": type = "Daily"; break;
                case "Sedmični": type = "Weekly"; break;
                case "Mjesečni": type = "Monthly"; break;
            }

            Report report = new Report { Date = DateOnly.FromDateTime(DateTime.Today), UserUserId = App._servicesProvider.GetRequiredService<Services.Storage>().User.UserId, Type = type};
            _context.Reports.Add(report);
            _context.SaveChanges();

            foreach (var item in items)
            {
                var bill = _context.Bills.FirstOrDefault(bill => bill.BillId == item.BillId);
                if (bill != null)
                {
                    if (bill.ReportReportId == null)
                    {
                        bill.ReportReportId = report.ReportId;
                        _context.SaveChanges();
                    }
                }
                else
                    return false;
            }
            return true;
        }

        public bool addStorage(string name, string location)
        {
            var result = _context.Storages.Any(storage => storage.Name.Equals(name));
            if (result)
            {
                return false;
            }
            else
            {
                Models.Storage storage = new Models.Storage { Name = name, Location = location };
                _context.Storages.Add(storage);
                _context.SaveChanges();
                return true;
            }
        }

        public List<NewOfferItem> getOffers()
        {
            List<NewOfferItem> list = new List<NewOfferItem>();
            List<Product> products = _context.Products.ToList();
            List<User> users = _context.Users.ToList();
            List<Models.OfferItem> items = _context.OfferItems.ToList();


            var offers = _context.Offers.Where(offer => offer.Accepted == (sbyte)0).ToList();
            foreach (var offer in offers)
            {
                var supplier = users.FirstOrDefault(user => user.UserId == offer.UserUserId);
                var offerItems = items.Where(of => of.OfferOfferId == offer.OfferId);

                NewOfferItem noi = new NewOfferItem { OfferId = offer.OfferId, SupplierName = supplier.CompanyName, SupplierJIB = supplier.Jib };
                noi.OfferItems = new List<NewOfferItems>();

                foreach (Models.OfferItem item in  offerItems)
                {
                    var product = products.FirstOrDefault(p => p.ProductId == item.ProductProductId);
                    NewOfferItems newOfferItems = new NewOfferItems { Id = product.ProductId, Name = product.Name, Price = product.Price.ToString(), Quantity = item.Quantity.ToString() };
                    noi.OfferItems.Add(newOfferItems);
                }

                list.Add(noi);
            }
            return list;
        }

        public void declineOffer(NewOfferItem noi)
        {
            var offer = _context.Offers.FirstOrDefault(offer => offer.OfferId == noi.OfferId);
            var offerItems = _context.OfferItems.Where(offerItem => offerItem.OfferOfferId == noi.OfferId).ToList();

            if (offer != null)
            {
                _context.Offers.Remove(offer);
                _context.SaveChanges();
            }
            if (offerItems.Any())
            {
                _context.OfferItems.RemoveRange(offerItems);
                _context.SaveChanges();
            }
        }

        public void acceptOffer(NewOfferItem offer, string storage)
        {
            var of = _context.Offers.FirstOrDefault(o => o.OfferId == offer.OfferId);
            of.Accepted = (sbyte)1;

            var store = _context.Storages.FirstOrDefault(s => s.Name.Equals(storage));

            var storageItems = _context.StorageItems.Where(s => s.StorageStorageId == store.StorageId).ToList();

            foreach(NewOfferItems item in offer.OfferItems)
            {
                if (storageItems.Count > 0)
                {
                    foreach (StorageItem str in storageItems)
                    {
                        var existingItem = _context.StorageItems.FirstOrDefault(si => si.StorageStorageId == store.StorageId && si.ProductProductId == item.Id);

                        if (existingItem == null)
                        {
                            StorageItem newItem = new StorageItem
                            {
                                StorageStorageId = store.StorageId,
                                ProductProductId = item.Id,
                                Quantity = Int32.Parse(item.Quantity)
                            };
                            _context.StorageItems.Add(newItem);
                        }
                        else
                        {
                            existingItem.Quantity += Int32.Parse(item.Quantity);
                        }
                    }
                } 
                else
                {
                    StorageItem newItem = new StorageItem
                    {
                        StorageStorageId = store.StorageId,
                        ProductProductId = item.Id,
                        Quantity = Int32.Parse(item.Quantity)
                    };
                    _context.StorageItems.Add(newItem);
                }
            }
            App._servicesProvider.GetRequiredService<ViewOffersViewModel>().deleteOffer(offer);
            _context.SaveChanges();
        }

        public void deleteProduct(int productID, int storageID)
        {
            var product = _context.StorageItems.FirstOrDefault(product => product.ProductProductId == productID && product.StorageStorageId == storageID);
            var cmbs = App._servicesProvider.GetRequiredService<CustomMessageBoxService>();
            if (product != null)
            {
                _context.StorageItems.Remove(product);
                _context.SaveChanges();
            } else
            {
                cmbs.Show("errorTitle", "ProductNotDeleted", System.Windows.MessageBoxButton.OK);
            }
        }
    }
}

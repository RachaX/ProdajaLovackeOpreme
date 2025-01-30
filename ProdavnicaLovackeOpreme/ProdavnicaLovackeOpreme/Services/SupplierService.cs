using Microsoft.Extensions.DependencyInjection;
using ProdavnicaLovackeOpreme.DB;
using ProdavnicaLovackeOpreme.Models;
using ProdavnicaLovackeOpreme.Util;
using System.IO;

namespace ProdavnicaLovackeOpreme.Services
{
    public class SupplierService : BaseService
    {
       private IServiceProvider _serviceProvider;
       private User? _user;

       public User User { get { return _user; } set { _user = value; } }
       public SupplierService(IServiceProvider serviceProvider) 
        { 
            _serviceProvider = serviceProvider;
            User = _serviceProvider.GetRequiredService<Storage>().User;
        }

        public void addProduct(string productName, double productPrice, string productCategory, string productDesc, string productImagePath)
        {        
            byte[] image = File.ReadAllBytes(productImagePath);

            if (productCategory.Equals("Puška"))
                productCategory = "Rifle";
            else if (productCategory.Equals("Pištolj"))
                productCategory = "Pistol";
            else if (productCategory.Equals("Optika"))
                productCategory = "Optic";
            else if (productCategory.Equals("Municija"))
                productCategory = "Ammunition";
            else
                productCategory = "Wear";

            Product product = new Product { Name=productName, Price = (decimal) productPrice, CategoryCategoryName = productCategory, Description = productDesc, Image = image, UserUserId = User.UserId};

            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public List<Product> getSupplierProducts()
        {
            List<Product> list = _context.Products.Where(u => u.UserUserId == User.UserId).ToList();
            return list;
        }

        public void createOffer(List<Util.OfferItem> list)
        {
            Offer offer = new Offer { UserUserId = User.UserId, Accepted = (sbyte)0 };
            _context.Offers.Add(offer);
            _context.SaveChanges();
            foreach (Util.OfferItem product in list)
            {
                Models.OfferItem offerItem = new Models.OfferItem { ProductProductId = product.Id, OfferOfferId = offer.OfferId, Quantity = product.Quantity };
                _context.OfferItems.Add(offerItem);
            }
            _context.SaveChanges();
        }
    }
}

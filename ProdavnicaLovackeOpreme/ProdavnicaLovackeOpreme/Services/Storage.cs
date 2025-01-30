using ProdavnicaLovackeOpreme.Models;
using ProdavnicaLovackeOpreme.Util;

namespace ProdavnicaLovackeOpreme.Services
{
    public class Storage
    {
        public User? User { get; set; }
        public List<ProductItem> BillItems { get; set; }
    }
}

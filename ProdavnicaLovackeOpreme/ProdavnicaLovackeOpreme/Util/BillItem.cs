using Microsoft.Extensions.DependencyInjection;
using ProdavnicaLovackeOpreme.Services;
using ProdavnicaLovackeOpreme.ViewModels;
using System.Windows.Navigation;

namespace ProdavnicaLovackeOpreme.Util
{
    public class BillItem : ObservableObject
    {
        private string _quantity;
        public string Name  { get; set; }
        public string Price { get; set; }
        public string Quantity { get { return _quantity; } set { _quantity = value; OnPropertyChanged(nameof(Quantity)); } }
        public int ProductId { get; set; }
        public int StorageId { get; set; }
    }
}

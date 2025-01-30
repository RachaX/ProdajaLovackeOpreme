using ProdavnicaLovackeOpreme.Services;

namespace ProdavnicaLovackeOpreme.Util
{
    public class OfferItem : ObservableObject
    {
        private int _id;
        private string _name;
        private string _category;
        private string _price;
        private int _quantity;
        private bool _isSelected;

        public int Id { get { return _id; } set { _id = value; OnPropertyChanged(nameof(Id)); } }
        public string Name { get => _name ?? string.Empty;  set { _name = value; OnPropertyChanged(nameof(Name)); } }
        public string Category { get => _category ?? string.Empty; set { _category = value; OnPropertyChanged(nameof(Category)); } }
        public string Price { get => _price ?? string.Empty; set { _price = value; OnPropertyChanged(nameof(Price)); } }
        public int Quantity { get => _quantity; set { _quantity = value; OnPropertyChanged(nameof(Quantity)); } }
        public bool IsSelected { get => _isSelected; set { _isSelected = value; OnPropertyChanged(nameof(IsSelected)); } }
    }
}

using ProdavnicaLovackeOpreme.Commands;
using ProdavnicaLovackeOpreme.Services;
using System.Windows.Controls;
using System.Windows.Media;

namespace ProdavnicaLovackeOpreme.Util
{
    public class ProductItem : ObservableObject
    {
        private bool? _isSelected;
        private RelayCommand _command;

        public int Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string Category { get; set; }
        public ImageSource Image { get; set; }
        public bool? IsSelected 
        { 
            get => _isSelected;
            set 
            {
                _isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
            }
        }
        public bool IsVisibleLocation { get; set; }
        public bool IsVisible { get; set; }
        public bool AllowedCommand { get; set; }
        public int? StorageId { get; set; }
        public string? StorageName { get; set; }

        public RelayCommand? DeleteProductCommand 
        { 
            get { return _command;  }
            set
            {
                _command = value;
                OnPropertyChanged(nameof(DeleteProductCommand));
            }
        }
    }
}

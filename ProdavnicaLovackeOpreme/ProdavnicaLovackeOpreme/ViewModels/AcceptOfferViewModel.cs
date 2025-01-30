using Microsoft.Extensions.DependencyInjection;
using Org.BouncyCastle.Asn1.Mozilla;
using ProdavnicaLovackeOpreme.Commands;
using ProdavnicaLovackeOpreme.Services;
using ProdavnicaLovackeOpreme.Util;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ProdavnicaLovackeOpreme.ViewModels
{
    public class AcceptOfferViewModel : ViewModelBase
    {
        private IServiceProvider _servideProvider;
        private ComboBoxItem _storage;

        public ObservableCollection<ComboBoxItem> Storages { get; set; }
        public ComboBoxItem Storage
        {
            get { return _storage; }
            set
            {
                _storage = value;
                OnPropertyChanged(nameof(Storage));
            }
        }

        public RelayCommand AcceptCommand { get; set; }
        public NewOfferItem Offer {  get; set; }
        public RelayCommand CancelCommand { get; set; }
        public event Action CloseAction;

        public AcceptOfferViewModel(IServiceProvider serviceProvider)
        { 
            _servideProvider = serviceProvider;
            Storages = new ObservableCollection<ComboBoxItem>();
            loadStorages();
            

            AcceptCommand = new RelayCommand(o =>
            {
                var service = _servideProvider.GetRequiredService<ManagerService>();
                service.acceptOffer(Offer, Storage.Content.ToString());
                CloseAction?.Invoke();
            }, o => true);

            CancelCommand = new RelayCommand(o =>
            {
                CloseAction?.Invoke();
            }, o => true);
        }

        public void loadStorages()
        {
            var service = _servideProvider.GetRequiredService<SalesmanService>();
            var list = service.loadStorages();
            foreach (var item in list)
            {
                Storages.Add(new ComboBoxItem { Content = item });
            }
        }
    }
}

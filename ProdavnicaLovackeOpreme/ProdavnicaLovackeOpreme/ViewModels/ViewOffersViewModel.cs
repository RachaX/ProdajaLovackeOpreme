using Microsoft.Extensions.DependencyInjection;
using ProdavnicaLovackeOpreme.Commands;
using ProdavnicaLovackeOpreme.Services;
using ProdavnicaLovackeOpreme.UserControls;
using ProdavnicaLovackeOpreme.Util;
using System.Collections.ObjectModel;

namespace ProdavnicaLovackeOpreme.ViewModels
{
    public class ViewOffersViewModel : ViewModelBase
    {
        private IServiceProvider _serviceProvider;

        public ObservableCollection<NewOfferItem> Offers { get; set; }
        public ViewOffersViewModel(IServiceProvider serviceProvider) 
        { 
            _serviceProvider = serviceProvider;
            Offers = new ObservableCollection<NewOfferItem>();
            loadOffers();
        }

        public void loadOffers()
        {
            var service = _serviceProvider.GetRequiredService<ManagerService>();
            List<NewOfferItem> newOfferItems = service.getOffers();

            foreach (NewOfferItem item in newOfferItems)
            {
                item.AcceptOffer = new RelayCommand(o =>
                {
                    var dialog = _serviceProvider.GetRequiredService<AcceptOfferWindow>();
                    _serviceProvider.GetRequiredService<AcceptOfferViewModel>().Offer = item;
                    dialog.ShowDialog();
                }, o => true);
                item.DeclineOffer = new RelayCommand(o =>
                {
                    Offers.Remove(item);
                    service.declineOffer(item);
                }, o => true);
                Offers.Add(item);
            }
        }

        public void deleteOffer(NewOfferItem offer)
        {
            Offers.Remove(offer);
        }

    }
}

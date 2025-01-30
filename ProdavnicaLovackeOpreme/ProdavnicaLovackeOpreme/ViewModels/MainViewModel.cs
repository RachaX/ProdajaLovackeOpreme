using ProdavnicaLovackeOpreme.Commands;
using ProdavnicaLovackeOpreme.Services;

namespace ProdavnicaLovackeOpreme.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private INavigationService _navigation; 

        public INavigationService Navigation
        { 
            get { return _navigation; }
            set
            {
                _navigation = value;
                OnPropertyChanged();
            } 
        }

        public RelayCommand NavigateHomeCommand { get; set; }
        public RelayCommand NavigateUserCommand { get; set; }

        public MainViewModel(INavigationService navService)
        {
            if (navService == null)
            {
                throw new ArgumentNullException(nameof(navService), "Navigation service is null!");
            }

            Navigation = navService;    
            NavigateHomeCommand = new RelayCommand(o => { Navigation.NavigateTo<HomeViewModel>();}, o => true);
            NavigateUserCommand = new RelayCommand(o => { Navigation.NavigateTo<UserViewModel>(); }, o => true);
        }
    }
}

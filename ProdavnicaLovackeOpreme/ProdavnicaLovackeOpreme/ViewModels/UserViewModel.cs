using Microsoft.Extensions.DependencyInjection;
using ProdavnicaLovackeOpreme.Commands;
using ProdavnicaLovackeOpreme.Services;
using ProdavnicaLovackeOpreme.Util;
using System.Collections.ObjectModel;

namespace ProdavnicaLovackeOpreme.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        private INavigationService? _navigation;
        private IServiceProvider _serviceProvider;
        private String? _username;
        private String? _userType;

        public INavigationService Navigation
        {
            get => _navigation;
            set
            {
                _navigation = value;
                OnPropertyChanged();
            }
        }

        public String Username
        {
            get => _username ?? string.Empty;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public String UserType
        {
            get => _userType ?? string.Empty;
            set
            {
                _userType = value;
                OnPropertyChanged(nameof(UserType));
            }
        }   
        public RelayCommand SettingsPage { get; set; }
        public ObservableCollection<MenuItem> Menu { get; set; }
        public UserViewModel(INavigationService navService, IServiceProvider serviceProvider)
        {
            Menu = new ObservableCollection<MenuItem>();
            _serviceProvider = serviceProvider;

            var user = _serviceProvider.GetRequiredService<Storage>().User ?? new Models.User();
            var userService = _serviceProvider.GetRequiredService<UserService>(); 

            Username = user.Username;
            UserType = user.Type;
            userService.logUser((sbyte)1);

            Navigation = navService;

            _serviceProvider.GetRequiredService<SettingsViewModel>().loadUserPreferences();

            if (UserType.Equals("Supplier"))
            {
                Navigation.NavigateTo<SupplierProductsViewModel>();
                Menu.Add(new MenuItem
                {
                    Text = (string)App.Current.Resources["viewSupplierProducts"],
                    Command = new RelayCommand(o => { 
                        Navigation.NavigateTo<SupplierProductsViewModel>(); 
                        _serviceProvider.GetRequiredService<SupplierProductsViewModel>().showProducts();
                    }, o => true),
                    Icon = "Pistol"
                });
                Menu.Add(new MenuItem
                {
                    Text = (string)App.Current.Resources["addProduct"],
                    Command = new RelayCommand(o => { Navigation.NavigateTo<AddProductViewModel>(); }, o => true),
                    Icon = "ShapeRectanglePlus"
                });
                Menu.Add(new MenuItem
                {
                    Text = (string)App.Current.Resources["createOffer"],
                    Command = new RelayCommand(o => { 
                        Navigation.NavigateTo<OfferViewModel>();                     
                        _serviceProvider.GetRequiredService<OfferViewModel>().showOfferItems(); 
                    }, o => true),
                    Icon = "Offer"
                });
            }
            else if(UserType.Equals("Manager"))
            {
                Navigation.NavigateTo<ViewProductsViewModel>();
                Menu.Add(new MenuItem
                {
                    Text = (string)App.Current.Resources["viewProducts"],
                    Command = new RelayCommand(o => {
                        _serviceProvider.GetRequiredService<ViewProductsViewModel>().setFilters();
                        Navigation.NavigateTo<ViewProductsViewModel>(); }, o => true),
                    Icon = "ViewAgendaOutline"
                });
                Menu.Add(new MenuItem
                {
                    Text = (string)App.Current.Resources["Reports"],
                    Command = new RelayCommand(o => { Navigation.NavigateTo<CreateReportViewModel>(); }, o => true),
                    Icon = "FileChart"
                });
                Menu.Add(new MenuItem
                {
                    Text = (string)App.Current.Resources["Offers"],
                    Command = new RelayCommand(o => { Navigation.NavigateTo<ViewOffersViewModel>(); }, o => true),
                    Icon = "HandCoinOutline"
                });
                Menu.Add(new MenuItem
                {
                    Text = (string)App.Current.Resources["viewEmployers"],
                    Command = new RelayCommand(o => { Navigation.NavigateTo<ViewWorkersViewModel>(); }, o => true),
                    Icon = "ListBoxOutline"
                });
                Menu.Add(new MenuItem
                {
                    Text = (string)App.Current.Resources["addStorage"],
                    Command = new RelayCommand(o => { Navigation.NavigateTo<AddStorageViewModel>(); }, o => true),
                    Icon = "StorePlus"
                });

            }
            else if(UserType.Equals("Salesman"))
            {
                Navigation.NavigateTo<ViewProductsViewModel>();
                Menu.Add(new MenuItem
                {
                    Text = (string)App.Current.Resources["viewProducts"],
                    Command = new RelayCommand(o => { Navigation.NavigateTo<ViewProductsViewModel>(); }, o => true),
                    Icon = "ViewAgendaOutline"
                });
                Menu.Add(new MenuItem
                {
                    Text = (string)App.Current.Resources["createBill"],
                    Command = new RelayCommand(o => { Navigation.NavigateTo<CreateBillViewModel>(); }, o => true),
                    Icon = "Printer"
                });
            }

            Menu.Add(new MenuItem
            {
                Text = (string)App.Current.Resources["settings"],
                Command = new RelayCommand(o => { Navigation.NavigateTo<SettingsViewModel>(); }, o => true),
                Icon = "Settings"
            });
            Menu.Add(new MenuItem
            {
                Text = (string)App.Current.Resources["shutdown"],
                Command = new RelayCommand(o => { userService.logUser((sbyte)0); App.Current.Shutdown(); }, o => true),
                Icon = "Power"
            });
        }
    }
}

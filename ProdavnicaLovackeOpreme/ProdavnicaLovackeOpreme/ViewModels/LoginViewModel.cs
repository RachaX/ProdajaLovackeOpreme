using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.DependencyInjection;
using ProdavnicaLovackeOpreme.Commands;
using ProdavnicaLovackeOpreme.Models;
using ProdavnicaLovackeOpreme.Services;
using ProdavnicaLovackeOpreme.Views;
using System.Windows;

namespace ProdavnicaLovackeOpreme.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private String? _username;
        private String? _password;
        private IServiceProvider _serviceProvider;

        public String Username
        {
            get => _username ?? string.Empty;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username)); 
            }
        }

        public String Password
        {
            get => _password ?? string.Empty;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public event Action DisableParentWindow;
        public event Action EnableParentWindow;
        public event Action CloseAction;
        public event Action DisableRegister;
        public static bool isDarkTheme {  get; set; }
        private readonly PaletteHelper palette = new PaletteHelper();
        public RelayCommand DarkThemeCommand { get; set; }
        public RelayCommand CloseApplicationCommand { get; set; }
        public RelayCommand LoginCommand { get; set; }
        public RelayCommand RegisterCommand { get; set; }

        public LoginViewModel(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            DisableParentWindow += () => Application.Current.Dispatcher.Invoke(() => Application.Current.MainWindow.IsEnabled = false);
            EnableParentWindow += () => Application.Current.Dispatcher.Invoke(() => Application.Current.MainWindow.IsEnabled = true);
            CloseAction += () => Application.Current.Dispatcher.Invoke(() => Application.Current.MainWindow.Close());
            DarkThemeCommand = new RelayCommand(o =>
            {
                ITheme theme = palette.GetTheme();
                if (isDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
                {
                    isDarkTheme = false;
                    theme.SetBaseTheme(Theme.Light);
                    Properties.Settings.Default.darkMode = false;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    isDarkTheme = true;
                    theme.SetBaseTheme(Theme.Dark);
                    Properties.Settings.Default.darkMode = true;
                    Properties.Settings.Default.Save();
                }
                palette.SetTheme(theme);
            }, o => true);

            CloseApplicationCommand = new RelayCommand(o =>
            {
                Application.Current.Shutdown();
            }, o => true);

            LoginCommand = new RelayCommand(async o =>
            {
                LoginService loginService = new LoginService();
                serviceProvider.GetRequiredService<LoadingViewModel>().Loading = true;
                User? user = await loginService.logUser(Username, Password);

                if (user != null)
                {
                    _serviceProvider.GetRequiredService<Services.Storage>().User = user;
                    _serviceProvider.GetRequiredService<UserWindow>().Show();
                    CloseAction?.Invoke();
                }
                else
                {
                    var cmbs = _serviceProvider.GetRequiredService<CustomMessageBoxService>();
                    cmbs.Show("errorTitle", "badCredentials", MessageBoxButton.OK);
                }
                serviceProvider.GetRequiredService<LoadingViewModel>().Loading = false;
            }, o => true);

            RegisterCommand = new RelayCommand(o => 
            {
                var registrationWindow = _serviceProvider.GetRequiredService<RegistrationWindow>();
                registrationWindow.Owner = Application.Current.MainWindow;
           
                DisableParentWindow?.Invoke();

                registrationWindow.Closed += (sender, e) =>
                {
                    EnableParentWindow?.Invoke();
                };

                registrationWindow.Show();
            }, o => true);
        }

    }
}

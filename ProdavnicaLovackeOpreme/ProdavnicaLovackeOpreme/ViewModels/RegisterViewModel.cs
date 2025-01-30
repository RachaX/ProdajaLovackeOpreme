using Microsoft.Extensions.DependencyInjection;
using ProdavnicaLovackeOpreme.Commands;
using ProdavnicaLovackeOpreme.Services;
using ProdavnicaLovackeOpreme.Views;
using System.Windows;
using System.Windows.Controls;

namespace ProdavnicaLovackeOpreme.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        private String? _username;
        private String? _password;
        private String? _repeatedPassword;
        private String? _name;
        private String? _surname;
        private ComboBoxItem? _accountType;
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

        public String RepeatedPassword
        {
            get => _repeatedPassword ?? string.Empty;
            set
            {
                _repeatedPassword = value;
                OnPropertyChanged(nameof(RepeatedPassword));
            }
        }

        public String Name
        {
            get => _name ?? string.Empty;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public String Surname
        {
            get => _surname ?? string.Empty;
            set
            {
                _surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }
        public ComboBoxItem AccountType
        {
            get => _accountType ?? new ComboBoxItem { Content = string.Empty };
            set
            {
                _accountType = value;
                OnPropertyChanged(nameof(AccountType));
            }
        }

        public event Action? CloseAction;
        public RelayCommand RegisterUser {  get; set; }
        public RelayCommand CloseWindow {  get; set; }
        public RegisterViewModel(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;    
           
            RegisterUser = new RelayCommand(o =>
            {
                if (string.IsNullOrEmpty(Username) && string.IsNullOrEmpty(Password) && string.IsNullOrEmpty(RepeatedPassword) && string.IsNullOrEmpty(Name) && string.IsNullOrEmpty(Surname) && string.IsNullOrEmpty(AccountType.Content.ToString()))
                {
                    var cmbs = _serviceProvider.GetRequiredService<CustomMessageBoxService>();
                    cmbs.Show("errorTitle", "allFieldsRequired", System.Windows.MessageBoxButton.OK);
                }
                else
                {
                    if (Password.Equals(RepeatedPassword))
                    {
                        RegistrationService service = new RegistrationService();
                        bool result = service.registerUser(Username, Password, Name, Surname, AccountType);
                        if (result)
                        {                
                            var cmbs = _serviceProvider.GetRequiredService<CustomMessageBoxService>();
                            cmbs.Show("successTitle", "registrationSuccedeed", System.Windows.MessageBoxButton.OK);
                            CloseAction?.Invoke();
                        }
                        else
                        {                          
                            var cmbs = _serviceProvider.GetRequiredService<CustomMessageBoxService>();
                            cmbs.Show("errorTitle", "errorWhileRegister", System.Windows.MessageBoxButton.OK);
                        }
                    }
                    else
                    {                   
                        var cmbs = _serviceProvider.GetRequiredService<CustomMessageBoxService>();
                        cmbs.Show("errorTitle", "passwordsDontMatch", System.Windows.MessageBoxButton.OK);
                    }
                }
            }, o => true);
            CloseWindow = new RelayCommand(o =>
            {
                CloseAction?.Invoke();
            }, o => true);
        }
    }
}

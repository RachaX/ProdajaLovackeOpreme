using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.DependencyInjection;
using ProdavnicaLovackeOpreme.Commands;
using ProdavnicaLovackeOpreme.Models;
using ProdavnicaLovackeOpreme.Services;
using System.Collections.ObjectModel;
using System.Security.RightsManagement;
using System.Windows;
using System.Windows.Controls;

namespace ProdavnicaLovackeOpreme.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        private ComboBoxItem? _theme;
        private ComboBoxItem? _mode;
        private ComboBoxItem? _font;
        private readonly PaletteHelper palette = new PaletteHelper();
        private IServiceProvider _serviceProvider;
        public ComboBoxItem? Theme
        {
            get => _theme;
            set 
            { 
                _theme = value;
                OnPropertyChanged(nameof(Theme));
            }
        }

        public ComboBoxItem? Mode
        {
            get => _mode;
            set
            {
                _mode = value;
                OnPropertyChanged(nameof(Mode));
            }
        }       

        public ComboBoxItem? Font
        {
            get => _font;
            set
            {
                _font = value;
                OnPropertyChanged(nameof(Font));
            }
        }

        public ObservableCollection<ComboBoxItem> themeOptions { get; set; }
        public ObservableCollection<ComboBoxItem> modeOptions { get; set; }
        public ObservableCollection<ComboBoxItem> fontOptions { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public SettingsViewModel(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            themeOptions = new ObservableCollection<ComboBoxItem>
            {
                new ComboBoxItem { Content = (string) App.Current.Resources["greenTheme"] },
                new ComboBoxItem { Content = (string) App.Current.Resources["blueTheme"] }
            };

            modeOptions = new ObservableCollection<ComboBoxItem>
            {
                new ComboBoxItem { Content = (string) App.Current.Resources["lightTheme"] },
                new ComboBoxItem { Content = (string) App.Current.Resources["darkTheme"] }
            };

            fontOptions = new ObservableCollection<ComboBoxItem>
            {
                new ComboBoxItem { Content = (string) App.Current.Resources["ArialFont"] },
                new ComboBoxItem { Content = (string) App.Current.Resources["RobotoFont"] },
                new ComboBoxItem { Content = (string) App.Current.Resources["HelveticaFont"] } ,
            };

            loadUserPreferences();
            SaveCommand = new RelayCommand(o =>
            {
                var userService = _serviceProvider.GetRequiredService<UserService>();
                int mode, theme; 
                string _mode = (string) Mode.Content.ToString();
                string _theme = (string) Theme.Content.ToString();
                string _font = (string) Font.Content.ToString();

                if (_mode.Equals("Light") || _mode.Equals("Svijetla"))
                    mode = 0;
                else
                    mode = 1;

                if (_mode.Equals("Green") || _mode.Equals("Zelena"))
                    theme = 0;
                else
                    theme = 1;
                userService.saveUserChanges(mode, theme, _font);

                setMode(_mode);
                setTheme(_theme);
                setFont(_font);
            }, o => true);
        }

        public void loadUserPreferences()
        {
            User? user = _serviceProvider.GetRequiredService<Services.Storage>().User;

            int mode = (int)user.Mode;
            Mode = modeOptions[mode];
            
            int theme = (int)user.Theme;
            Theme = themeOptions[theme];
           

            String font = user.Font;
            if(font.Equals("Arial"))
                Font = fontOptions[0];
            else if(font.Equals("Roboto"))
                Font = fontOptions[1];
            else
                Font = fontOptions[2];

            setMode(Mode.Content.ToString());
            setTheme(Theme.Content.ToString());
            setFont(Font.Content.ToString());
        }

        private void setMode(String mode)
        {
            ITheme theme = palette.GetTheme();
            if (mode.Equals("Light") || mode.Equals("Svijetla"))
                theme.SetBaseTheme(MaterialDesignThemes.Wpf.Theme.Light);
            else
                theme.SetBaseTheme(MaterialDesignThemes.Wpf.Theme.Dark);

            palette.SetTheme(theme);
        }

        private void setTheme(String themee)
        {
            ITheme theme = palette.GetTheme();
            if(themee.Equals("Green") || themee.Equals("Zelena"))
            {
                theme.SetPrimaryColor(System.Windows.Media.Colors.Green);
                theme.SetSecondaryColor(System.Windows.Media.Colors.Blue);
            }
            else
            {
                theme.SetPrimaryColor(System.Windows.Media.Colors.Blue);
                theme.SetSecondaryColor(System.Windows.Media.Colors.Green);
            }

            palette.SetTheme(theme);
        }

        private void setFont(string font)
        {
            Application.Current.Resources["AppFont"] = new System.Windows.Media.FontFamily(font);
        }

    }
}

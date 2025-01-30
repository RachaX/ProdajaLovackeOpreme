using ProdavnicaLovackeOpreme.ViewModels;
using System.Windows;
using System.Windows.Input;
using System.Globalization;
using System.Windows.Controls;
using MaterialDesignThemes.Wpf;
using ProdavnicaLovackeOpreme.UserControls;

namespace ProdavnicaLovackeOpreme.Views
{
    public partial class LoginWindow : Window
    {
        private readonly PaletteHelper palette = new PaletteHelper();

        public LoginWindow()
        {
            InitializeComponent();
            setLang(Properties.Settings.Default.lang.ToUpper());
            setTheme(Properties.Settings.Default.darkMode);
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private void langButton_Click(object sender, RoutedEventArgs e)
        {
            setLang(((Button)sender).Tag.ToString());
        }

        private void setLang(string lang)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(lang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);

            var existingLangDict = Application.Current.Resources.MergedDictionaries.FirstOrDefault(d => d.Source != null && d.Source.OriginalString.Contains("Dictionary-"));

            if (existingLangDict != null)
            {
                Application.Current.Resources.MergedDictionaries.Remove(existingLangDict);
            }

            ResourceDictionary dict = new ResourceDictionary()
            {
                Source = new Uri($"/Dictionary/Dictionary-{lang}.xaml", UriKind.Relative)
            };

            Application.Current.Resources.MergedDictionaries.Add(dict);
            srButton.IsEnabled = true;
            enButton.IsEnabled = true;

            switch(lang)
            {
                case "EN":
                    enButton.IsEnabled = false;
                    break;
                case "SR":
                    srButton.IsEnabled = false;
                    break;
                default:
                    break;
            }

            Properties.Settings.Default.lang = lang;
            Properties.Settings.Default.Save();
        }

        private void setTheme(bool darkMode)
        {
            ITheme theme = palette.GetTheme();
            theme.SetBaseTheme(darkMode ? Theme.Dark : Theme.Light);
            palette.SetTheme(theme);

            LoginViewModel.isDarkTheme = darkMode;
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var context = this.DataContext;

            if(context is LoginViewModel loginViewModel)
            {
                loginViewModel.Password = txtPassword.Password;
            }
        }
    }
}

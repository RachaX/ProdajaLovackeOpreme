using ProdavnicaLovackeOpreme.ViewModels;
using System.Globalization;
using System.Windows;

namespace ProdavnicaLovackeOpreme.Views
{
    public partial class CustomMessageBox : Window
    {
        private readonly CustomMessageBoxViewModel _viewModel;
        public CustomMessageBox(CustomMessageBoxViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.CloseAction = result => { this.DialogResult = result; };
            DataContext = _viewModel;

            InitializeComponent();
            setLanguage();
        }

        public void Initialize(string titleKey, string messageKey, MessageBoxButton buttons)
        {
            _viewModel.Title = (string)Application.Current.Resources[titleKey];
            _viewModel.Message = (string)Application.Current.Resources[messageKey];
            ShowButtons(buttons);
        }

        private void setLanguage()
        {
            var currentCulture = CultureInfo.CurrentCulture.Name;

            if (currentCulture.StartsWith("sr"))
            {
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
                {
                    Source = new Uri($"/Dictionary/Dictionary-{currentCulture}.xaml", UriKind.Relative)
                });
            }
            else
            {
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
                {
                    Source = new Uri($"/Dictionary/Dictionary-{currentCulture}.xaml", UriKind.Relative)
                });
            }
        }

        private void ShowButtons(MessageBoxButton buttons)
        {
            OkButton.Visibility = Visibility.Collapsed;
            YesButton.Visibility = Visibility.Collapsed;
            NoButton.Visibility = Visibility.Collapsed;
            CancelButton.Visibility = Visibility.Collapsed;

            switch (buttons)
            {
                case MessageBoxButton.OK:
                    OkButton.Visibility = Visibility.Visible;
                    break;
                case MessageBoxButton.YesNo:
                    YesButton.Visibility = Visibility.Visible;
                    NoButton.Visibility = Visibility.Visible;
                    break;
                case MessageBoxButton.YesNoCancel:
                    YesButton.Visibility = Visibility.Visible;
                    NoButton.Visibility = Visibility.Visible;
                    CancelButton.Visibility = Visibility.Visible;
                    break;
                default:
                    OkButton.Visibility = Visibility.Visible;
                    break;
            }
        }
    }
}

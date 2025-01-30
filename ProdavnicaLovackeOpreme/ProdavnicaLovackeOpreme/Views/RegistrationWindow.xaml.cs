using ProdavnicaLovackeOpreme.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace ProdavnicaLovackeOpreme.Views
{
    public partial class RegistrationWindow : Window
    {       
        private readonly RegisterViewModel _viewModel;
        public RegistrationWindow(RegisterViewModel vm)
        {
            _viewModel = vm;
            _viewModel.CloseAction += () => this.Close();
            DataContext = _viewModel;
            InitializeComponent();
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var context = this.DataContext;

            if (context is RegisterViewModel viewModel)
            {
                viewModel.Password = txtPassword.Password;
            }
        }

        private void txtRepeatedPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var context = this.DataContext;

            if (context is RegisterViewModel viewModel)
            {
                viewModel.RepeatedPassword = txtRepeatedPassword.Password;
            }
        }
    }
}

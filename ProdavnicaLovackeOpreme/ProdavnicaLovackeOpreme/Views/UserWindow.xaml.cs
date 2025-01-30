
using ProdavnicaLovackeOpreme.ViewModels;

namespace ProdavnicaLovackeOpreme.Views
{
    public partial class UserWindow
    {
        private readonly UserViewModel _userViewModel;
        public UserWindow(UserViewModel _viewModel)
        {
            _userViewModel = _viewModel;
            DataContext = _userViewModel;
            InitializeComponent();
        }
    }
}

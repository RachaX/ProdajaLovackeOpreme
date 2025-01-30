using Microsoft.Extensions.DependencyInjection;
using ProdavnicaLovackeOpreme.ViewModels;
using System.Windows.Controls;

namespace ProdavnicaLovackeOpreme.UserControls
{
    public partial class LoadingUserControl : UserControl
    {
        public LoadingUserControl()
        {
            InitializeComponent();
            DataContext = App._servicesProvider.GetRequiredService<LoadingViewModel>();
        }
    }
}

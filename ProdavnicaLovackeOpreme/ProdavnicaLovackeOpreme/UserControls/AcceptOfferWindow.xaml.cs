using Microsoft.Extensions.DependencyInjection;
using ProdavnicaLovackeOpreme.ViewModels;
using System.Windows;

namespace ProdavnicaLovackeOpreme.UserControls
{
    public partial class AcceptOfferWindow : Window
    {
        private readonly AcceptOfferViewModel viewModel;
        public AcceptOfferWindow(AcceptOfferViewModel vm)
        {
            InitializeComponent();

            viewModel = vm;
            viewModel.CloseAction += () => { this.Close();  };
            DataContext = viewModel;

        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using ProdavnicaLovackeOpreme.Services;
using ProdavnicaLovackeOpreme.ViewModels;
using ProdavnicaLovackeOpreme.Views;
using ProdavnicaLovackeOpreme.UserControls;
using System.Windows;

namespace ProdavnicaLovackeOpreme
{
    public partial class App : Application
    {
        public static ServiceProvider _servicesProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<INavigationService, NavigationService>();
            
            services.AddSingleton<LoginViewModel>();
            services.AddSingleton<LoginWindow>(provider => new LoginWindow
            {
                DataContext = provider.GetRequiredService<LoginViewModel>()
            });

            services.AddSingleton<RegisterViewModel>();
            services.AddSingleton<RegistrationWindow>();

            services.AddTransient<CustomMessageBoxViewModel>();
            services.AddTransient<CustomMessageBox>();
            services.AddSingleton<CustomMessageBoxService>();
            services.AddSingleton<Storage>();
            services.AddSingleton<LoadingViewModel>();
            services.AddSingleton<LoadingUserControl>();

            services.AddSingleton<UserWindow>();
            services.AddSingleton<UserViewModel>();

            services.AddSingleton<SettingsViewModel>();
            services.AddSingleton<SettingsUserControl>();

            services.AddSingleton<AddProductViewModel>();
            services.AddSingleton<AddProductUserControl>();

            services.AddSingleton<UserService>();

            services.AddSingleton<SupplierProductsViewModel>();
            services.AddSingleton<SupplierProductsUserControl>();
            services.AddSingleton<SupplierService>();

            services.AddSingleton<OfferViewModel>();
            services.AddSingleton<CreateOfferUserControl>();
            services.AddSingleton<ViewProductsViewModel>();
            services.AddSingleton<ViewProductsUserControl>();

            services.AddSingleton<CreateBillViewModel>();
            services.AddSingleton<CreateBillUserControl>();
            services.AddSingleton<ViewWorkersViewModel>();
            services.AddSingleton<ViewWorkersUserControl>();

            services.AddSingleton<SalesmanService>();
            services.AddSingleton<ManagerService>();

            services.AddSingleton<CreateReportViewModel>();
            services.AddSingleton<CreateReportUserControl>();
            services.AddSingleton<AddStorageViewModel>();   
            services.AddSingleton<AddStorageUserControl>();
            services.AddSingleton<ViewOffersViewModel>();
            services.AddSingleton<ViewOffersUserControl>();
            services.AddSingleton<AcceptOfferViewModel>();
            services.AddSingleton<AcceptOfferWindow>();

            services.AddSingleton<Func<Type, ViewModelBase>>(serviceProvider => viewModelType => (ViewModelBase) serviceProvider.GetRequiredService(viewModelType));

            _servicesProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        { 
            var loginWindow = _servicesProvider.GetRequiredService<LoginWindow>();
            _servicesProvider.GetRequiredService<INavigationService>().NavigateTo<LoginViewModel>();
            loginWindow.Show();

            base.OnStartup(e);
        }
    }

}

using Microsoft.Extensions.DependencyInjection;
using ProdavnicaLovackeOpreme.Views;
using System.Windows;

namespace ProdavnicaLovackeOpreme.Services
{
    class CustomMessageBoxService : ICustomMessageBoxService
    {
        private readonly IServiceProvider _serviceProvider;

        public CustomMessageBoxService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public bool? Show(string titleKey, string messageKey, MessageBoxButton buttons = MessageBoxButton.OK)
        {
            var customMessageBox = _serviceProvider.GetRequiredService<CustomMessageBox>();
            customMessageBox.Initialize(titleKey, messageKey, buttons);
            return customMessageBox.ShowDialog();
        }
    }
}

using System.Windows;

namespace ProdavnicaLovackeOpreme.Services
{
    public interface ICustomMessageBoxService
    {
        bool? Show(string titleKey, string messageKey, MessageBoxButton buttons = MessageBoxButton.OK);
    }
}

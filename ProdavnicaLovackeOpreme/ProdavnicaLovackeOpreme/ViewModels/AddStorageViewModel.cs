using Microsoft.Extensions.DependencyInjection;
using ProdavnicaLovackeOpreme.Commands;
using ProdavnicaLovackeOpreme.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdavnicaLovackeOpreme.ViewModels
{
    public class AddStorageViewModel : ViewModelBase
    {
        private IServiceProvider _serviceProvider;
        private String _name;
        private String _location;

        public String Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public String Location
        {
            get { return _location; }
            set
            {
                _location = value;
                OnPropertyChanged(nameof(Location));
            }
        }

        public RelayCommand AddStorageCommand { get; set; }

        public AddStorageViewModel(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
            var service = _serviceProvider.GetRequiredService<ManagerService>();

            AddStorageCommand = new RelayCommand(o =>
            {
                var cmbs = _serviceProvider.GetRequiredService<CustomMessageBoxService>();
                if(Name.Equals("") || Location.Equals(""))
                {
                    cmbs.Show("errorTitle", "fillAllFields", System.Windows.MessageBoxButton.OK);
                }
                else
                {
                    if(service.addStorage(Name, Location))
                    {
                        cmbs.Show("successTitle", "storageAdded", System.Windows.MessageBoxButton.OK);
                    }
                    else
                    {
                        cmbs.Show("errorTitle", "storageNameAlreadyExists", System.Windows.MessageBoxButton.OK);
                        Name = ""; 
                    }
                }
            }, o => true);
        }

    }
}

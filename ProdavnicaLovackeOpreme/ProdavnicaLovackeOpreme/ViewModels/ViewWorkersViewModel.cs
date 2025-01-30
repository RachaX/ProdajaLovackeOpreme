using Microsoft.Extensions.DependencyInjection;
using ProdavnicaLovackeOpreme.Services;
using ProdavnicaLovackeOpreme.Util;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ProdavnicaLovackeOpreme.ViewModels
{
    public class ViewWorkersViewModel : ViewModelBase
    { 
        private IServiceProvider _serviceProvider;
        private ComboBoxItem _working;

        public ObservableCollection<ComboBoxItem> IsWorking { get; set; }
      
        public ComboBoxItem Working
        {
            get => _working;
            set
            {
              
                _working = value;
                showEmployers(_working.Content.ToString());
                OnPropertyChanged(nameof(Working));
            }
        }

        public ObservableCollection<Employer> Employers { get; set; }
        public ViewWorkersViewModel(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
            IsWorking = new ObservableCollection<ComboBoxItem>();
            Employers = new ObservableCollection<Employer>();

            showOptions();
        }

        public void showOptions()
        {
            IsWorking.Add(new ComboBoxItem { Content = (string)App.Current.Resources["allEmployers"] });
            IsWorking.Add(new ComboBoxItem { Content = (string)App.Current.Resources["loggedInEmployers"] });
            IsWorking.Add(new ComboBoxItem { Content = (string)App.Current.Resources["loggedOutEmployers"] });
            Working = IsWorking[0];
        }

        public void showEmployers(string type)
        {
            var service = _serviceProvider.GetRequiredService<ManagerService>();

            ObservableCollection<Employer> employers = service.loadEmployers(type);
            Employers.Clear(); 
            foreach(var employer in employers)
            {
                Employers.Add(employer);
            }
        }
    }
}

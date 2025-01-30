using Microsoft.Extensions.DependencyInjection;
using ProdavnicaLovackeOpreme.Commands;
using ProdavnicaLovackeOpreme.Services;
using ProdavnicaLovackeOpreme.Util;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ProdavnicaLovackeOpreme.ViewModels
{
    public class CreateReportViewModel : ViewModelBase
    {
        private IServiceProvider _serviceProvider;
        private ComboBoxItem _type;
        private string _price;

        public RelayCommand CreateReportCommand { get; set; }

        public ObservableCollection<ReportItem> ReportItems { get; set; }

        public string Price 
        {
            get => _price; 
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        public ObservableCollection<ComboBoxItem> ReportsType { get; set; }
        public ComboBoxItem Type 
        {
            get => _type; 
            set
            {
                _type = value;
                showReportItems(_type.Content.ToString());
                calculatePrice(ReportItems);
                OnPropertyChanged(nameof(Type));
            }
        }


        public CreateReportViewModel(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
            ReportItems = new ObservableCollection<ReportItem>();

            showTypes();

            CreateReportCommand = new RelayCommand(o =>
            {
                var cmbs = _serviceProvider.GetRequiredService<CustomMessageBoxService>();
                var service = _serviceProvider.GetRequiredService<ManagerService>();
                if (ReportItems.Count > 0)
                {
                    if (service.createReport(ReportItems, Type.Content.ToString()))
                    {
                        cmbs.Show("successTitle", "reportCreated", System.Windows.MessageBoxButton.OK);
                        ReportItems.Clear();
                    }
                    else
                    {
                        cmbs.Show("errorTitle", "errorWhileCreatingReport", System.Windows.MessageBoxButton.OK);
                    }
                }
                else
                {
                    cmbs.Show("errorTitle", "noDataForReport", System.Windows.MessageBoxButton.OK);
                }
            }, o => true);
        }

        private void showTypes()
        {
            ReportsType = new ObservableCollection<ComboBoxItem>();
            ReportsType.Add(new ComboBoxItem { Content = (string)App.Current.Resources["Day"] });
            ReportsType.Add(new ComboBoxItem { Content = (string)App.Current.Resources["Week"] });
            ReportsType.Add(new ComboBoxItem { Content = (string)App.Current.Resources["Month"] });
        }
        
        private void showReportItems(string type)
        {
            var service = _serviceProvider.GetRequiredService<ManagerService>();

            List<ReportItem> items = service.getReportItems(type);

            ReportItems.Clear();
            foreach (ReportItem item in items)
            {
                ReportItems.Add(item);
            }       
        }

        private void calculatePrice(ObservableCollection<ReportItem> items)
        {
            double sum = 0;
            foreach (ReportItem item in items)
            {
                sum += item.Price * item.Quantity;
            }
            Price = sum.ToString();
        }
    }
}

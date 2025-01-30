using ProdavnicaLovackeOpreme.Commands;

namespace ProdavnicaLovackeOpreme.ViewModels
{
    public class CustomMessageBoxViewModel : ViewModelBase
    {
        private string _title;
        private string _message;

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand OkCommand { get; }
        public RelayCommand YesCommand { get; }
        public RelayCommand NoCommand { get; }
        public RelayCommand CancelCommand { get; }

        public bool? DialogResult { get; private set; }

        public Action<bool?> CloseAction { get; set; }

        public CustomMessageBoxViewModel()
        {

            OkCommand = new RelayCommand(
                o =>
                {
                    DialogResult = true;
                    CloseAction?.Invoke(DialogResult);
                }, o => true
            );

            YesCommand = new RelayCommand(
                o =>
                {
                    DialogResult = true;
                    CloseAction?.Invoke(DialogResult);
                }, o => true
            );

            NoCommand = new RelayCommand(
                o =>
                {
                    DialogResult = false;
                    CloseAction?.Invoke(DialogResult);
                }, o => true
            );

            CancelCommand = new RelayCommand(
                o =>
                {
                    DialogResult = null;
                    CloseAction?.Invoke(DialogResult);
                }, o => true
            );
        }

  
    }
}

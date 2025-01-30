namespace ProdavnicaLovackeOpreme.ViewModels
{
    public class LoadingViewModel : ViewModelBase
    {
        private bool _loading = false;

        public bool Loading
        {
            get { return _loading; }
            set
            {
                _loading = value;
                OnPropertyChanged(nameof(Loading));
            }
        }
    }
}

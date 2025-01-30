using ProdavnicaLovackeOpreme.ViewModels;

namespace ProdavnicaLovackeOpreme.Services
{
    public interface INavigationService
    {
        ViewModelBase CurrentView {  get; }
        void NavigateTo<T>() where T : ViewModelBase;
     }

    public class NavigationService : ObservableObject, INavigationService
    {
        private ViewModelBase _currentView;
        private readonly Func<Type, ViewModelBase> _viewModelFactory;    

        public ViewModelBase CurrentView 
        {
            get => _currentView;
            private set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public NavigationService(Func<Type, ViewModelBase> viewModelBase)
        {
            _viewModelFactory = viewModelBase;
        }

        public void NavigateTo<TViewModel>() where TViewModel : ViewModelBase
        {
            ViewModelBase vm = _viewModelFactory.Invoke(typeof(TViewModel));
            CurrentView = vm;
        }
    }
}

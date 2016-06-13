
using GalaSoft.MvvmLight;
using Notes.Views;

namespace Notes.ViewModels
{
    using GalaSoft.MvvmLight.Views;

    public class MainViewModel : ViewModelBase
{
        private readonly NavigationService _navigationService;
      
        public MainViewModel()
        {
            _navigationService = new NavigationService();
            _navigationService.Configure("CreateNote", typeof(CreateNote));
            _navigationService.Configure("ReadNote", typeof(ReadNote));
            _navigationService.Configure("SearchNotes", typeof(SearchNotes));
            _navigationService.Configure("Settings", typeof(Settings));
            _navigationService.Configure("EditNote", typeof(EditNote));
            }

        public void NavigateToPage2()
        {
            _navigationService.NavigateTo("CreateNote");
        }

        public void NavigateToPage3()
        {
            _navigationService.NavigateTo("ReadNote");
        }

        public void NavigateToPage4()
        {
            _navigationService.NavigateTo("SearchNotes");
        }

        public void NavigateToPage5()
        {
            _navigationService.NavigateTo("Settings");
        }

        public void NavigateBack()
        {
            _navigationService.GoBack();
        }

        
}
}

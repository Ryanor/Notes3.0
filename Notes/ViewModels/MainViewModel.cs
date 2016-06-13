
using GalaSoft.MvvmLight;
using Notes.Views;

namespace Notes.ViewModels
{
    using GalaSoft.MvvmLight.Views;

    public class MainViewModel : ViewModelBase
{
        private readonly INavigationService navigationService;
      

        public MainViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        public void NavigateToPage2()
        {
            navigationService.NavigateTo("CreateNote");
        }

        public void NavigateToPage3()
        {
            navigationService.NavigateTo("ReadNote");
        }

        public void NavigateToPage4()
        {
            navigationService.NavigateTo("SearchNotes");
        }

        public void NavigateToPage5()
        {
            navigationService.NavigateTo("Settings");
        }

        public void NavigateBack()
        {
            navigationService.GoBack();
        }

        
}
}

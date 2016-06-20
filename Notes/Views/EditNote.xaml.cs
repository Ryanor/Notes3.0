using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Notes.ViewModels;
using Windows.UI.Xaml.Navigation;
using Notes.Models;

namespace Notes.Views
{
    
    public sealed partial class EditNote : Page
    {
        public EditNote()
        {
            this.InitializeComponent();
        }

        EditViewModel ViewModel => DataContext as EditViewModel;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel.LoadNote(e.Parameter);
            //ViewModel.LoadLocation();
            ((App)App.Current).OnBackRequested += OnBackRequested;
            base.OnNavigatedTo(e);
        }

        
        private void OnBackRequested(object sender, BackRequestedEventArgs backRequestedEventArgs)
        {
            backRequestedEventArgs.Handled = true;
            ViewModel.NavigateBack();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            ((App)App.Current).OnBackRequested -= OnBackRequested;
            base.OnNavigatedFrom(e);
        }
    }

}

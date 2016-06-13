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
            base.OnNavigatedTo(e);
        }
    }
}

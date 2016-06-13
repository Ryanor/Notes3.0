using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Notes.ViewModels;



namespace Notes.Views
{

    public sealed partial class SearchNotes : Page
    {
        public SearchNotes()
        {
            this.InitializeComponent();

        }
        public SearchViewModel ViewModel => DataContext as SearchViewModel;

       /* protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel.LoadList();
            base.OnNavigatedTo(e);
        }*/

       /* public void Refresh()
        {
            Bindings.StopTracking();

            Bindings.Update();
        }*/

    }
}

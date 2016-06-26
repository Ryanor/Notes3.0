using Windows.UI.Xaml.Controls;
using Notes.ViewModels;
using Windows.UI.Xaml.Navigation;

namespace Notes.Views
{

    public sealed partial class Settings : Page
    {
        public Settings()
        {
            this.InitializeComponent();
        }

        SettingsViewModel ViewModel => DataContext as SettingsViewModel;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel.Load();
            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            ViewModel.Save();
            base.OnNavigatingFrom(e);
        }
    }
}

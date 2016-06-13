using Windows.UI.Xaml.Controls;
using Notes.ViewModels;


namespace Notes.Views
{

    public sealed partial class Settings : Page
    {
        public Settings()
        {
            this.InitializeComponent();
        }

        SettingsViewModel ViewModel => DataContext as SettingsViewModel;

    }
}

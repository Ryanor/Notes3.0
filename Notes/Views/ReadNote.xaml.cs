using Windows.UI.Xaml.Controls;
using Notes.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Notes.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ReadNote : Page
    {
        

        public ReadNote()
        {
            this.InitializeComponent();
        }

        public ReadViewModel ViewModel => DataContext as ReadViewModel;
    }
}

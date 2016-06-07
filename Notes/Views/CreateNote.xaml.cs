using System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Notes.ViewModels;

namespace Notes.Views
{
    public sealed partial class CreateNote : Page //, INotifyPropertyChanged


    {
        
        DispatcherTimer dispatcherTimer = new DispatcherTimer();

        public MainViewModel ViewModel => DataContext as MainViewModel;

        public CreateNote()
        {    
            this.InitializeComponent();

            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);

            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Start();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            ((Application)Application.Current).OnBackRequested += OnOnBackRequested;
        }

        private void dispatcherTimer_Tick(object sender, object e)
        {
           
            BoxForTime.Text = DateTime.Now.ToString();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            ((Application)Application.Current).OnBackRequested -= OnOnBackRequested;
        }

        private void OnOnBackRequested(object sender, BackRequestedEventArgs backRequestedEventArgs)
        {
            backRequestedEventArgs.Handled = true;
            ViewModel.CancelNewNote();
        }
    }
}

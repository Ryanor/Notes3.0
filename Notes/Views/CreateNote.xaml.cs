using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Notes.ViewModels;


namespace Notes.Views
{
    using System.ComponentModel;
    using Windows.ApplicationModel.Background;

    public sealed partial class CreateNote : Page //, INotifyPropertyChanged


    {
        public string DemoString { get; set; }

        public MainViewModel ViewModel => DataContext as MainViewModel;

        public CreateNote()
        {
            this.InitializeComponent();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ((Application)Application.Current).OnBackRequested += OnOnBackRequested;
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

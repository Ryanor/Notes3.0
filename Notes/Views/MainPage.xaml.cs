using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Windows.UI;
using Notes.Views;
using Notes.ViewModels;

namespace Notes.Views
{

    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            this.InitializeComponent();
        }

        public MainViewModel ViewModel => DataContext as MainViewModel;

       private void ButtonNew_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CreateNote), "Welcome to new Note section!");
        }

        private void ButtonRead_Click(object sender, RoutedEventArgs e)
        {
             this.Frame.Navigate(typeof(ReadNote));
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SearchNotes));
        }

        private void ButtonSettings_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Settings));
        }
    }
}

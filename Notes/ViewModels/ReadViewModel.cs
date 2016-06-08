using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using Notes.Models;

namespace Notes.ViewModels
{
    public class ReadViewModel : ViewModelBase
    {
        private readonly NavigationService _navigationService;
        public double NumberOfNotes => new ViewModelLocator().MainViewModel.NumberOfNotes;
        public IEnumerable<Note> ReadList => new ViewModelLocator().MainViewModel.AllNotes.Take((int)NumberOfNotes);

        public ReadViewModel()
        {

            _navigationService = new NavigationService();
        }


        public void NavigateBack()
        {
            _navigationService.GoBack();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using Notes.Models;
using Notes.Services;

namespace Notes.ViewModels
{
    using System;
    using GalaSoft.MvvmLight.Views;
    using GalaSoft.MvvmLight.Command;

    public class CreateViewModel : ViewModelBase
    {
        private readonly NavigationService _navigationService;
        private readonly IDataService dataService;


        public CreateViewModel(IDataService _dataService)
        {
            
            _navigationService = new NavigationService();
            this.dataService = _dataService;
        }

        public string NewTextTitle { get; set; }
        public string NewTextNote { get; set; }

        public void SaveNewNote()
        {
            if (!String.IsNullOrEmpty(NewTextTitle) && !String.IsNullOrEmpty(NewTextNote))
            {
                var note = new Note(NewTextTitle, NewTextNote, DateTime.Now);
                dataService.SaveNote(note);
                NewTextTitle = String.Empty;
                NewTextNote = String.Empty;
                _navigationService.GoBack();
               
            }
        }

        public void CancelNewNote()
        {
            if (String.IsNullOrEmpty(NewTextTitle))
            {

                _navigationService.GoBack();
            }
            else
            {
                DialogService dialog = new DialogService();
                dialog.ShowMessage("Your note is not saved, Cancel without saving?", "Note not saved!", "Quit anyway", "Let me return",
                    confirmed =>
                    {
                        if (confirmed)
                        {
                            NewTextTitle = String.Empty;
                            NewTextNote = String.Empty;
                            _navigationService.GoBack();
                        }

                    });
            }
        }
    }
}


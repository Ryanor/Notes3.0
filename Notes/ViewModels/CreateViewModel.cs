﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using Notes.Models;

namespace Notes.ViewModels
{
    using System;
    using GalaSoft.MvvmLight.Views;
    using GalaSoft.MvvmLight.Command;

    public class CreateViewModel : ViewModelBase
    {
        private readonly NavigationService _navigationService;
        

        public CreateViewModel()
        {
            
            _navigationService = new NavigationService();
        }

        public string NewTextTitle { get; set; }
        public string NewTextNote { get; set; }

        public void SaveNewNote()
        {
            if (!String.IsNullOrEmpty(NewTextTitle))
            {
                var vm = (new ViewModelLocator()).MainViewModel;
                vm.AllNotes.Add(new Note(NewTextTitle, NewTextNote, DateTime.Now));
                _navigationService.GoBack();
                NewTextTitle = String.Empty;
                NewTextNote = String.Empty;
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

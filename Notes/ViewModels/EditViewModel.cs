using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using Notes.Models;
using Notes.Services;

namespace Notes.ViewModels
{
    public class EditViewModel : ViewModelBase
    {
        private readonly NavigationService navigationService;
        private readonly IDataService dataService;
        public IEnumerable<Note> EditNote;
        public string EditNoteTitle { get; set; }
        public string EditNoteContent { get; set; }
        public DateTime EditNoteDate { get; set; }

        private Note EditedNote;

        public string ChangedNoteTitle { get; set; }
        public string ChangedNoteContent { get; set; }

        public EditViewModel(IDataService _dataService)
        {
            navigationService = new NavigationService();
            this.dataService = _dataService;
          
        }

        public void LoadNote(object note)
        {
            EditedNote = dataService.GetAllNotes().Single(n => n.Equals(note));
            ChangedNoteContent = EditNoteTitle = EditedNote.NoteTitle;
            ChangedNoteContent = EditNoteContent = EditedNote.NoteContent;
            EditNoteDate = EditedNote.Date;
        }

        public bool HasNoteChanged
            => !(EditNoteTitle.Equals(ChangedNoteTitle) && EditNoteContent.Equals(ChangedNoteContent));

        public void SaveEditedNote()
        {
            if (HasNoteChanged)
            {
                DialogService dialog = new DialogService();
                dialog.ShowMessage("Save changes to note?", "Save changes", "YES, save", "NO, let me return",
                    confirmed =>
                    {
                        if (confirmed)
                        {
                            dataService.DeleteNote(EditedNote);
                            dataService.SaveNote(new Note(EditNoteTitle, EditNoteContent,EditNoteDate));
                            navigationService.GoBack();
                        }
                    });
            }
        }

        public void DeleteEditedNote()
        {
            DialogService dialog = new DialogService();
            dialog.ShowMessage("Do you really want to delete the selected note?", "Delete selected note!", "YES, delete", "NO, let me return",
                confirmed =>
                {
                    if (confirmed)
                    {
                        dataService.DeleteNote(EditedNote);
                        navigationService.GoBack();
                    }
                }); 
        }

        public void NavigateBack()
        {
            if (HasNoteChanged)
            {
                DialogService dialog = new DialogService();
                dialog.ShowMessage("Cancel without saving changes?", "Cancel edit mode!", "YES, cancel", "NO, let me return",
                    confirmed =>
                    {
                        if (confirmed)
                        {
                            navigationService.GoBack();
                        }
                    });
            }
            else
            {
                navigationService.GoBack();
            }
           
        }
    }
}

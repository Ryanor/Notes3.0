using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.Graphics.DirectX.Direct3D11;
using Notes.Models;
using Notes.Services;
using PropertyChanged;

namespace Notes.ViewModels
{

    public class SearchViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IDataService dataService;
        private readonly SettingsViewModel settings;

        public string SearchString { get; set; }
        public DateTimeOffset FromDateTime { get; set; }
        public DateTimeOffset ToDateTime { get; set; }
         
        public IEnumerable<Note> ReadList
        {
            get
            {
                var getnotes = dataService.GetAllNotes();

                if (IsSearchByDate)
                {
                    getnotes = getnotes.Where(n => n.Date.Date >= FromDateTime.Date && n.Date.Date <= ToDateTime.Date);
                }
                else
                {
                    getnotes = getnotes.Where(n => n.NoteTitle.Contains(SearchString) || n.NoteContent.Contains(SearchString));
                }

                getnotes = (settings.IsSortAscending) ? getnotes.OrderBy(n => n.Date)
                                                      : getnotes.OrderByDescending(n => n.Date);
                return getnotes;
            }
        }

        public SearchViewModel(IDataService _dataService, SettingsViewModel settings, INavigationService navigationService)
        {
            _navigationService = navigationService;
            this.dataService = _dataService;
            this.settings = settings;
            SearchString = String.Empty;
            FromDateTime = new DateTimeOffset(DateTime.Now.AddDays(-14));
            ToDateTime = new DateTimeOffset(DateTime.Now);
        }


        public bool IsSearchByDate { get; set; }


        public Note SelectedNote { get; set; }
        public bool IsNoteSelected => SelectedNote != null;

        public void NavigateToPage6()
        {
            _navigationService.NavigateTo("EditNote", SelectedNote);
        }

        public void DeleteNote()
        {

            DialogService dialog = new DialogService();
            dialog.ShowMessage("Do you really want to delete the selected note?", "Delete selected note!", "YES, delete", "NO, let me return",
                confirmed =>
                {
                    if (confirmed)
                    {
                        dataService.DeleteNote(SelectedNote);
                        RaisePropertyChanged(() => ReadList);
                    }

                });
        }

        public void NavigateBack()
        {
            _navigationService.GoBack();
        }
    }
}

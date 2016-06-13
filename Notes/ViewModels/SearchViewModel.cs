using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Notes.Models;
using Notes.Services;
using PropertyChanged;

namespace Notes.ViewModels
{

    public class SearchViewModel : ViewModelBase
    {
        private readonly NavigationService _navigationService;
        private readonly IDataService dataService;
        private readonly SettingsViewModel settings;

        public string SearchString { get; set; }
        public DateTimeOffset FromDateTime { get; set; }
        public DateTimeOffset ToDateTime { get; set; }

        public IEnumerable<Note> ReadList;

        public SearchViewModel(IDataService _dataService, SettingsViewModel settings)
        {
            _navigationService = new NavigationService();
            this.dataService = _dataService;
            this.settings = settings;
            SearchString = String.Empty;
            FromDateTime = new DateTimeOffset(DateTime.Now.AddDays(-14));
            ToDateTime = new DateTimeOffset(DateTime.Now);
        }

        public void LoadList()
        {
            var getnotes = dataService.GetAllNotes();
            
            getnotes = getnotes.Where(n => n.Date >= FromDateTime && n.Date <= ToDateTime);
            getnotes = getnotes.Where(n => n.NoteTitle.Contains(SearchString) || n.NoteContent.Contains(SearchString));
            getnotes = (settings.IsSortAscending) ? getnotes.OrderBy(n => n.Date) 
                                                  : getnotes.OrderByDescending(n => n.Date);
            ReadList = new ObservableCollection<Note>(getnotes);
        }

        public void NavigateBack()
        {
            _navigationService.GoBack();
        }
    }
}

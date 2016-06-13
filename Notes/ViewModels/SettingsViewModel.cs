using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using Notes.Services;
using Notes.Models;

namespace Notes.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IDataService dataService;
        private readonly IStorageService storageService;

        public int NumberOfNotes { get; set; } = 1;
        public bool IsSortAscending { get; set; } = true;
        public int MaximumNumberOfNotes
        {
            get
            {
                var notes = dataService.GetAllNotes();

                if (notes != null)
                {
                    return notes.Count();
                }
                else
                {
                    return 1;
                }
            }
        }
        

        public SettingsViewModel(IDataService _dataService, IStorageService storageService, INavigationService navigationService)
        {
            this._navigationService = navigationService;
            this.dataService = _dataService;
            this.storageService = storageService;
            Load();
        }


        public void Save()
        {
            storageService.Write(nameof(NumberOfNotes), NumberOfNotes);
            storageService.Write(nameof(IsSortAscending), IsSortAscending);

            var notes = dataService.GetAllNotes();
            storageService.Write("notes", notes);
        }

        public void Load()
        {
            dataService.ClearNotes();

            NumberOfNotes = storageService.Read<int>(nameof(NumberOfNotes), 1);
            IsSortAscending = storageService.Read<bool>(nameof(IsSortAscending), true);
            ObservableCollection<Note> notes = storageService.Read<ObservableCollection<Note>>("notes",new ObservableCollection<Note>());
            foreach (var note in notes)
            {
                dataService.SaveNote(note);
            }
        }
    }
}

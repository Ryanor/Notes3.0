using System;
using System.Collections.Generic;
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
        private readonly NavigationService _navigationService;
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
        

        public SettingsViewModel(IDataService _dataService, IStorageService storageService)
        {
            _navigationService = new NavigationService();
            this.dataService = _dataService;
            this.storageService = storageService;
        }


        public void Save()
        {
           /* storageService.Write(nameof(NumberOfNotes), NumberOfNotes);
            storageService.Write(nameof(IsSortAscending), IsSortAscending);

            var notes = dataService.GetAllNotes();
            foreach (var note in notes)
            {
                storageService.Write(nameof(note), note);
            }*/
        }

        public void Load()
        {
          /*  NumberOfNotes = storageService.Read<int>(nameof(NumberOfNotes), 5);
            IsSortAscending = storageService.Read<bool>(nameof(IsSortAscending), true);

            while (!storageService.Equals(null))
            {
                dataService.SaveNote(storageService.Read<Note>(nameof(Note), new Note("Hallo","Hallo",DateTime.Now)));
            }*/
        }
    }
}

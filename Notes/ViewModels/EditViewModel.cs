using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.Devices.Geolocation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using GalaSoft.MvvmLight.Messaging;
using Notes.Models;
using Notes.Services;
using Windows.UI.Xaml.Controls.Maps;
using Windows.Storage.Streams;

namespace Notes.ViewModels
{
    public class EditViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;
        private readonly IDataService dataService;

       // public IEnumerable<Note> EditNote;
        public string EditNoteTitle { get; set; }
        public string EditNoteContent { get; set; }
        public DateTime EditNoteDate { get; set; }
        public Geopoint EditNoteLocation { get; set; }
        

        private Note EditedNote;

        public string ChangedNoteTitle { get; set; }
        public string ChangedNoteContent { get; set; }

        public EditViewModel(IDataService _dataService, INavigationService navigationService)
        {
            this.navigationService = navigationService;
            this.dataService = _dataService;
          
        }

        public void LoadNote(object note)
        {
            EditedNote = dataService.GetAllNotes().Single(n => n.Equals(note));
            ChangedNoteTitle = EditNoteTitle = EditedNote.NoteTitle;
            ChangedNoteContent = EditNoteContent = EditedNote.NoteContent;
            EditNoteDate = EditedNote.Date;
            EditNoteLocation = new Geopoint(new BasicGeoposition()
            {
                Longitude = EditedNote.Longitude,
                Latitude = EditedNote.Latitude
                    
            });
        }

        public Geopoint Center { get; set; } = new Geopoint(new BasicGeoposition() { Longitude = 20.0, Latitude = 10.0 });
        public double Zoomlevel { get; set; } = 5.0;

       

        public async void LoadLocation()
        {
            var access = await Geolocator.RequestAccessAsync();

            switch (access)
            {
                case GeolocationAccessStatus.Allowed:

                    var geolocator = new Geolocator();
                    var geopositon = await geolocator.GetGeopositionAsync();
                    var geopoint = geopositon.Coordinate.Point;

                    Center = EditNoteLocation;
                    Zoomlevel = 5;
                    break;

                case GeolocationAccessStatus.Unspecified:
                case GeolocationAccessStatus.Denied:
                    break;
            }
        }


        public bool HasNoteChanged
            => (!EditNoteTitle.Equals(ChangedNoteTitle) || !EditNoteContent.Equals(ChangedNoteContent));

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
                            dataService.SaveNote(new Note(EditNoteTitle, EditNoteContent,EditNoteDate, EditNoteLocation));
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

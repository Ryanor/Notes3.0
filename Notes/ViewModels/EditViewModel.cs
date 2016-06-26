using System;
using Windows.Devices.Geolocation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using Notes.Models;
using Notes.Services;

namespace Notes.ViewModels
{
    public class EditViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;
        private readonly IDataService dataService;

        // Note Note is the selected note from the read note or the search note view
        public Note Note { get; set; }


        public EditViewModel(IDataService _dataService, INavigationService navigationService)
        {
            this.navigationService = navigationService;
            this.dataService = _dataService;

            PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(Note))
                {
                    Note.PropertyChanged += (s, e) => HasNoteChanged = true;
                }
            };
        }


        public Geopoint Center { get; set; } = new Geopoint(new BasicGeoposition() { Longitude = 20.0, Latitude = 10.0 });
        public double Zoomlevel { get; set; } = 12.0;

        public async void LoadLocation()
        {
            var access = await Geolocator.RequestAccessAsync();

            switch (access)
            {
                case GeolocationAccessStatus.Allowed:

                    var geolocator = new Geolocator();
                    var geopositon = await geolocator.GetGeopositionAsync();
                    var geopoint = geopositon.Coordinate.Point;

                    Center = new Geopoint(new BasicGeoposition() { Latitude = Note.Latitude, Longitude = Note.Longitude });
                        
                    Zoomlevel = 15;
                    break;

                case GeolocationAccessStatus.Unspecified:
                case GeolocationAccessStatus.Denied:
                    break;
            }
        }


        public bool HasNoteChanged { get; set; }
            

        public void SaveEditedNote()
        {
            if (HasNoteChanged)
            {
                DialogService dialog = new DialogService();
                dialog.ShowMessage("Save changes to note?", "Save changes", "YES, save", "NO, let me return",
                    async confirmed =>
                    {
                        if (confirmed)
                        {
                            await dataService.SaveNote(Note);
                            navigationService.GoBack();
                        }
                    });
            }
        }

        public void DeleteEditedNote()
        {
            DialogService dialog = new DialogService();
            dialog.ShowMessage("Do you really want to delete the selected note?", "Delete selected note!", "YES, delete", "NO, let me return",
                async confirmed =>
                {
                    if (confirmed)
                    {
                        await dataService.DeleteNote(Note);
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

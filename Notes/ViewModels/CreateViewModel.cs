using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
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
        private readonly INavigationService _navigationService;
        private readonly IDataService dataService;

        public CreateViewModel(IDataService _dataService, INavigationService navigationService)
        {
            
            this._navigationService = navigationService;
            this.dataService = _dataService;
        }

        public string NewTextTitle { get; set; }
        public string NewTextNote { get; set; }
        public Geopoint NewNoteLocation { get; set; }

        public async void SaveNewNote()
        {
            if (!String.IsNullOrEmpty(NewTextTitle) && !String.IsNullOrEmpty(NewTextNote))
            {
                var access = await Geolocator.RequestAccessAsync();

                switch (access)
                {
                    case GeolocationAccessStatus.Allowed:

                        var geolocator = new Geolocator();
                        var geopositon = await geolocator.GetGeopositionAsync();
                        var geopoint = geopositon.Coordinate.Point;
                        NewNoteLocation = geopoint;

                        break;

                    case GeolocationAccessStatus.Unspecified:
                    case GeolocationAccessStatus.Denied:
                        break;
                }

                var note = new Note(NewTextTitle, NewTextNote, DateTime.Now, NewNoteLocation);
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


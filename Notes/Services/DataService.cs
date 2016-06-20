using System;
using System.Collections.Generic;
using Windows.Devices.Geolocation;
using Notes.Models;

namespace Notes.Services
{
    public class DataService : IDataService
    {
        private readonly List<Note> _notes;

        public DataService()
        {
            _notes = new List<Note>();
/*            {
                new Note("Hallo Message", "Halli Hallo, ich bin eine kleine Nachricht!", DateTime.Now.AddDays(-2), new Geopoint(new BasicGeoposition() {Latitude = 14.25, Longitude = 48.02})),
                new Note("Hallo", "asdfjklö,asdfjklö", DateTime.Now.AddDays(-1), new Geopoint(new BasicGeoposition() {Latitude = 14.51, Longitude = 48.36})),
                new Note("Hoi", "jkadjkgjakdjgkajgkjdfj", DateTime.Now, new Geopoint(new BasicGeoposition() {Latitude = 14.5, Longitude = 48.34}))
            };*/
        }

        public void DeleteNote(Note note)
        {
            _notes.Remove(note);
        }

        public void ClearNotes()
        {
            _notes.Clear();
        }

        public IEnumerable<Note> GetAllNotes()
        {
            return _notes;
        }

        public void SaveNote(Note note)
        {
           _notes.Add(note);
        }
    }
}

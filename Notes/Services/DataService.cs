using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notes.Models;
using Windows.Devices.Geolocation;

namespace Notes.Services
{
    public class DataService : IDataService
    {
        private readonly List<Note> _notes;

        public DataService()
        {
            _notes = new List<Note>()
            {
                new Note("Hallo Message", "Halli Hallo, ich bin eine kleine Nachricht!", DateTime.Now.AddDays(-2),new Geopoint(new BasicGeoposition () { Longitude = 34.0, Latitude = 23.12})),
                new Note("Hallo", "asdfjklö,asdfjklö", DateTime.Now.AddDays(-1), new Geopoint(new BasicGeoposition () { Longitude = 34.0, Latitude = 23.12})),
                new Note("Hoi", "jkadjkgjakdjgkajgkjdfj", DateTime.Now, new Geopoint(new BasicGeoposition () { Longitude = 34.0, Latitude = 23.12}))
            };
        }

        public async Task<IEnumerable<Note>> GetAllNotes()
        {
            return _notes;
        }

        public async Task AddNote(Note note)
        {
            _notes.Add(note);
        }

        public async Task SaveNote(Note note)
        {
            note.Date = DateTime.Now;
        }

        public async Task DeleteNote(Note note)
        {
            _notes.Remove(note);
        }      
    }
}

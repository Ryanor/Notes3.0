using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notes.Models;

namespace Notes.Services
{
    public interface IDataService
    {
        IEnumerable<Note> GetAllNotes();

        void SaveNote(Note note);
        void DeleteNote(Note note);
        void ClearNotes();
    }
}

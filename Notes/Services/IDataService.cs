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
        Task <IEnumerable<Note>> GetAllNotes();
        Task AddNote(Note note);
        Task SaveNote(Note note);
        Task DeleteNote(Note note);
        
    }
}

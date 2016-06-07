using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace Notes.Models
{
    public class Note
    {
        public string TextNote { get; set; }
        public DateTime Date {get; set; }

        public Note(string textNote, DateTime date)
        {
            this.TextNote = textNote;
            this.Date = date;
        }

        public string NoteContext
        {
            get
            {
                if (TextNote.Length <= 10)
                {
                    
                    return $"{TextNote}";
                }
                else
                {
                    return $"{TextNote}".Substring(0,10);
                }
            }
        }

        /*public override string ToString()
        {
            return NoteContext;
        }*/
    }
}

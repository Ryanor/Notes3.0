using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using GalaSoft.MvvmLight;

namespace Notes.Models
{
    public class Note
    {
        public string NoteTitle { get; set; }
        public string NoteContent { get; set; }
        public DateTime Date { get; set; }
        public double Longitude { get; set; } = 20;
        public double Latitude { get; set; } = 20;


        public Note(string noteTitle, string noteContent, DateTime date, Geopoint geopoint)
        {
            this.NoteTitle = noteTitle;
            this.NoteContent = noteContent;
            this.Date = date;
            if (geopoint != null)
            {
                this.Longitude = geopoint.Position.Longitude;
                this.Latitude = geopoint.Position.Latitude;
            }
         
        }
    

 public string Title
        {
            get
            {
                if (NoteTitle.Length <= 15)
                {
                    return $"{NoteTitle}";
                }
                else
                {
                    return $"{NoteTitle}".Substring(0, 15) + $"...";
                }
            }
        }

        public string NoteContext
        {
            get
            {
                if (NoteContent.Length <= 15)
                {

                    return $"{NoteContent}";
                }
                else
                {
                    return $"{NoteContent}".Substring(0, 15) + $"...";
                }
            }
        }

        public string FormattedDate => Date.ToString("dd-MM-yyyy / hh:mm:ss");
    }
}

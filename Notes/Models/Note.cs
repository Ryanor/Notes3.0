using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using GalaSoft.MvvmLight;
using Newtonsoft.Json;

namespace Notes.Models
{
    public class Note : ObservableObject
    {
        public int Id { get; set; }
        
        public string Title { get; set; }

        
        public string Content { get; set; }

        [JsonProperty("CreatedAt")]
        public DateTime Date { get; set; }

        public double Longitude { get; set; } = 20;

        public double Latitude { get; set; } = 20;

        

        public Note(string noteTitle, string noteContent, DateTime date, Geopoint geopoint)
        {
            this.Title = noteTitle;
            this.Content = noteContent;
            this.Date = date;
            if (geopoint != null)
            {
                this.Longitude = geopoint.Position.Longitude;
                this.Latitude = geopoint.Position.Latitude;
            }
         
        }
    

 public string NoteTitle
        {
            get
            {
                if (Title.Length <= 15)
                {
                    return $"{Title}";
                }
                else
                {
                    return $"{Title}".Substring(0, 15) + $"...";
                }
            }
        }

        public string NoteContext
        {
            get
            {
                if (Content.Length <= 15)
                {

                    return $"{Content}";
                }
                else
                {
                    return $"{Content}".Substring(0, 15) + $"...";
                }
            }
        }

        public string FormattedDate => Date.ToString("dd-MM-yyyy / hh:mm:ss");
    }
}

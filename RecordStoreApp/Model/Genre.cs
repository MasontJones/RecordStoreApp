using System;
using System.Collections.Generic;
using System.Text;

namespace RecordStoreApp.Model
{
    public class Genre
    {
        public int genreID { get; set; }
        public string genreName { get; set; }
        public int merchID { get; set; }
        public string artist { get; set; } 
        public string name { get; set; }
        public override string ToString()
        {
            return $"{merchID}, {name} by {artist}";
        }
    }
}

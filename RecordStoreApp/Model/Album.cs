using System;
using System.Collections.Generic;
using System.Text;

namespace RecordStoreApp.Model
{
    public class Album
    {
        public int albumID { get; set; }
        public int merchID { get; set; }
        public string albumName { get; set; }
        public string artist { get; set; }
        public int genreID {get; set;}
        public override string ToString()
        {
            return $"{albumName}, by {artist}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace RecordStoreApp.Model
{
    public class Track
    {
        public int trackID { get; set; }
        public int merchID { get; set; }
        public string trackName { get; set; }
        public int albumID { get; set; }
        public int genreID { get; set; }
        public string artist { get; set; }
        public int numAvaliable { get; set; }

        public override string ToString()
        {
            return $"{trackName}, by {artist}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace RecordStoreApp.Model
{
   public class Merchandise
    {
        public int merchID { get; set; }
        public string merchName { get; set; }
        public string merchArtist { get; set; }
        public double price { get; set; }
        public int available { get; set; }
        public string merchType { get; set; }
        public override string ToString()
        {
            return $"ID is {merchID}, {merchName}, costs ${price}, {available} are avaliable";
        }
    }
}

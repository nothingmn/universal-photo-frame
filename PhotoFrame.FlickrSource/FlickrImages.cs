using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoFrame.FlickrSource
{
    public class FlickrImages
    {
        public string title { get; set; }
        public string link { get; set; }
        public string description { get; set; }
        public DateTime modified { get; set; }
        public string generator { get; set; }
        public Item[] items { get; set; }
    }

    public class Item
    {
        public string title { get; set; }
        public string link { get; set; }
        public Media media { get; set; }
        public DateTime date_taken { get; set; }
        public string description { get; set; }
        public DateTime published { get; set; }
        public string author { get; set; }
        public string author_id { get; set; }
        public string tags { get; set; }
    }

    public class Media
    {
        public string m { get; set; }
    }

}

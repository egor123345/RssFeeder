using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rss_feeder.Models
{
    public class Item
    {
        public string Title {get; set;}
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime PubDate { get; set; }

    }
}

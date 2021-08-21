using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rss_feeder.Models
{
    public class FeedSettings
    {
        public FeedSettings() { }
        public FeedSettings(string BaseRss, int FreqUpd)
        {
            this.FreqUpd = FreqUpd;
            this.BaseRss = BaseRss;
        }
       public string BaseRss { get; set; }
       public int FreqUpd { get; set; }
       public List<string> RssChannels { get; set; }

    }
}

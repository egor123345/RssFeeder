using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rss_feeder.Models
{
    public class FeedSettings
    {
        public FeedSettings() { }
        public FeedSettings(string SrcSites, int FreqUpd)
        {
            this.FreqUpd = FreqUpd;
            this.SrcSites = SrcSites;
        }
       public string SrcSites { get; set; }
       public int FreqUpd { get; set; }

    }
}

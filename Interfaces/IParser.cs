using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rss_feeder.Models;

namespace rss_feeder.Interfaces
{
    interface IParser
    {
        IEnumerable<Item> Parse(string src_text);
    }
}

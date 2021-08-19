using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rss_feeder.Interfaces;
using rss_feeder.Models;

namespace rss_feeder.Parsers
{
    public class XmlParser : IParser
    {
        public IEnumerable<Item> Parse(string src_text)
        {
            List<Item> items = new List<Item>();
            return items;
        }
    }
}

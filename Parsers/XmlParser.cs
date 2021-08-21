using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rss_feeder.Interfaces;
using rss_feeder.Models;
using System.Xml.Linq;

namespace rss_feeder.Parsers
{
    public class XmlParser : IParser
    {
        public IEnumerable<Item> Parse(string src_text)
        {
            List<Item> items = new List<Item>();
            XDocument xmlDoc = XDocument.Load(src_text);
            XElement xRss = xmlDoc.Element("rss");
            XElement xChannel = xRss.Element("channel");
            foreach (XElement xItem  in xChannel.Elements("item").ToList())
            {
                Item item = new Item
                {
                    Title = xItem.Element("title").Value,
                    Description = xItem.Element("description").Value,
                    PubDate = DateTime.Parse(xItem.Element("pubDate").Value)
                };
                item.PubDate =  item.PubDate.AddHours(-3);
                item.Url = xItem.Element("link").Value;
                items.Add(item);
            }

            return items;
        }
    }
}

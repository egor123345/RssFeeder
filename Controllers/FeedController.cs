﻿using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using rss_feeder.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using rss_feeder.Interfaces;
using rss_feeder.Parsers;

namespace rss_feeder.Controllers
{
    public class FeedController : Controller
    {
        private readonly ILogger<FeedController> _logger;

        public string JsonPath = "FeedSettings.json";
        public FeedController(ILogger<FeedController> logger)
        {
            _logger = logger;
        }

        public IActionResult deleterss(string rssChannel)
        {
            string jsonString = System.IO.File.ReadAllText(JsonPath);
            FeedSettings settings = JsonSerializer.Deserialize<FeedSettings>(jsonString);
            settings.RssChannels.Remove(rssChannel);
            jsonString = JsonSerializer.Serialize<FeedSettings>(settings);
            System.IO.File.WriteAllText(JsonPath, jsonString);
            return PartialView(settings);
        }
        public IActionResult Habr()
        {

            string jsonString = System.IO.File.ReadAllText(JsonPath);
            FeedSettings settings = JsonSerializer.Deserialize<FeedSettings>(jsonString);
            IParser parser = new XmlParser();
            IEnumerable<Item> items = parser.Parse(settings.BaseRss);
            ViewBag.FreqUpd = settings.FreqUpd;
            return View(items);
        }

        [HttpGet]
        public IActionResult Settings()
        {

            string jsonString = System.IO.File.ReadAllText(JsonPath);
            FeedSettings settings = JsonSerializer.Deserialize<FeedSettings>(jsonString);
            return View(settings);
        }

        [HttpPost]
        public IActionResult Settings(string BaseRss, int FreqUpd)
        {
            FeedSettings settings = new FeedSettings(BaseRss, FreqUpd);

            string jsonString = JsonSerializer.Serialize<FeedSettings>(settings);
            System.IO.File.WriteAllText(JsonPath, jsonString);
            return Settings();
        }

      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

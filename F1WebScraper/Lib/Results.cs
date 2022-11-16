﻿using CsvHelper;
using HtmlAgilityPack;

namespace F1WebScraper.Lib;

public static class Results
{
    public static List<string> GetResults(int year, int raceNumber)
    {
        var noRace = 1124 + raceNumber;
        var results = new List<string>();
        var url = $"https://www.formula1.com/en/results.html/{year}/races/{noRace}/race-result.html";
        HtmlWeb web = new HtmlWeb();
        HtmlDocument doc = web.Load(url);
        var tableXPath = "//tr";
        var resultsNodes = doc.DocumentNode.SelectNodes(tableXPath).Skip(1).Select(x => x.ChildNodes[5].InnerHtml);
        //doc.DocumentNode.SelectNodes("//tr")[1].ChildNodes[3]
        foreach (var resultsNode in resultsNodes)
        {
            results.Add(resultsNode);
        }
        return results;
    }
}
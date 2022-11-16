using CsvHelper;
using HtmlAgilityPack;

namespace F1WebScraper.Lib;

public class Results
{
    public List<string> GetResults(int year, int raceNumber)
    {
        var noRace = 1124 + raceNumber;
        HtmlWeb web = new HtmlWeb();
        HtmlDocument doc = web.Load($@"https://www.formula1.com/en/results.html/{year}/races/{noRace}/race-result.html");
        return new List<string>();
    }
}
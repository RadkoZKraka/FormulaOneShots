using FormulaOneShots.Data;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using Excel = Microsoft.Office.Interop.Excel;

namespace FormulaOneShots.Models
{
    public static class SeedData
    {
        static Dictionary<string, List<Dictionary<string, List<string>>>> Seed()
        {
            //słownik osób w których jest lista wyścigów która składa się z nazwy wyścigu i listy wyników
            var shots = new Dictionary<string, List<Dictionary<string, List<string>>>>();
            using (var package =
                   new ExcelPackage(new FileInfo(@"/Users/radoslawkrowcki/Documents/Formula1-strzały.xlsx")))
            {
                //nie mam bladego pojęcia kaj działa
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                var worksheetLoc = 2;
                for (int i = 0; i < 5; i++)
                {
                    var currentSheet = package.Workbook.Worksheets[worksheetLoc];

                    var row = 3;
                    for (int j = 0; j < 5; j++)
                    {
                        var column = 2;
                        for (int k = 0; k < 5; k++)
                        {
                            if (j == 4 && k == 2)
                            {
                                break;
                            }

                            var list = new List<Dictionary<string, List<string>>>();
                            var races = new Dictionary<string, List<string>>();
                            var currentRace = currentSheet.Cells[row - 2, column - 1].Text;

                            races.Add(currentRace,
                                new List<string>(currentSheet.Cells[row, column, row + 25, column]
                                    .Select(x => (string) x.Value)
                                    .ToList()));

                            list.Add(races);

                            if (!shots.ContainsKey(currentSheet.Name))
                            {
                                shots.Add(currentSheet.Name, new List<Dictionary<string, List<string>>>(list));
                            }

                            shots[currentSheet.Name].Add(races);

                            column += 3;
                        }

                        row += 29;
                    }

                    worksheetLoc++;
                }

                var r = 3;
            }

            return shots;
        }

        public static void Initialize(IServiceProvider serviceProvider)
        {
            var shots = Seed();
            using (var context = new GuessesContext(
                       serviceProvider.GetRequiredService<
                           DbContextOptions<GuessesContext>>()))
            {
                // Look for any movies.
                if (context.Shots.Any())
                {
                    return; // DB has been seeded
                }

                var id = 0;
                var position = 1;

                foreach (var person in shots)
                {
                    foreach (var race in person.Value)
                    {
                        foreach (var guess in race)
                        {
                            var results = race.Values.SelectMany(x => x).ToList();
                            var result = new List<Result>();
                            foreach (var driver in results)
                            {
                                result.Add(new Result()
                                {
                                    Driver = driver,
                                    Id = position
                                });
                                position++;
                            }

                            context.Shots.Add(new Shots()
                            {
                                Id = id,
                                LastChange = DateTime.Now,
                                PolePosition = guess.Value[guess.Value.Count - 1] ?? "BRAK",
                                Race = guess.Key,
                                RandomGuess = guess.Value.Last() ?? "BRAK",
                                Results = result,
                                User = "admin",
                                Year = 2022
                            });
                            id++;
                        }
                    }
                }

                context.SaveChanges();
            }
        }
    }
}
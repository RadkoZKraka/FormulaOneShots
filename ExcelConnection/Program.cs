// See https://aka.ms/new-console-template for more information

using OfficeOpenXml;

static void Seed()
{
    var shots = new Dictionary<string, List<Dictionary<string,List<string>>>>();
    using(var package = new ExcelPackage(new FileInfo(@"/Users/radoslawkrowcki/Documents/Formula1-strzały.xlsx")))
    {
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
                        new List<string>(currentSheet.Cells[row, column, row + 25, column].Select(x => (string) x.Value)
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
}
Seed();
Console.WriteLine("Hello, World!");
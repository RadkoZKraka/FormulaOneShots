using FormulaOneShots.Data;
using Microsoft.EntityFrameworkCore;
using Excel = Microsoft.Office.Interop.Excel;
namespace FormulaOneShots.Models
{
    public static class SeedData
    {
        public static void Seed()
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"Formula1-strzały.xlsx");
            Excel.Worksheet xlWorksheet = (Excel.Worksheet)xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;
                
        }
        public static void Initialize(IServiceProvider serviceProvider)
        {
            
            using (var context = new GuessesContext(
                       serviceProvider.GetRequiredService<
                           DbContextOptions<GuessesContext>>()))
            {
                // Look for any movies.
                if (context.Shots.Any())
                {
                    return;   // DB has been seeded
                }

                context.Shots.AddRange();
                context.SaveChanges();
            }
        }
    }
}
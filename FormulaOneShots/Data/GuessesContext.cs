using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FormulaOneShots.Models;

namespace FormulaOneShots.Data
{
    public class GuessesContext : DbContext
    {
        public GuessesContext (DbContextOptions<GuessesContext> options)
            : base(options)
        {
        }

        public DbSet<FormulaOneShots.Models.Shots> Shots { get; set; } = default!;
    }
}

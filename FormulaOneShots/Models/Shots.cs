using System.ComponentModel.DataAnnotations;

namespace FormulaOneShots.Models;

public class Shots
{
    public int Id { get; set; }
    public string User { get; set; }
    public int Year { get; set; }
    public string Race { get; set; }
    public List<Result> Results { get; set; } = new List<Result>(20);
    public string PolePosition { get; set; }
    public string? RandomGuess { get; set; }
    
    [DataType(DataType.Date)]
    public DateTime LastChange { get; set; }
    
}

public class Result
{
    [Key]
    public int Id { get; set; }

    public string Driver { get; set; }
}
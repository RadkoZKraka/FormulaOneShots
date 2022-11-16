namespace FormulaOneShots.Lib;

public class DriversMap
{
    public List<string> GetDriversNumbers(List<string> drivers)
    {
        var driversNumbers = new List<string>();
        foreach (var driver in drivers)
        {
            switch (driver)
            {
                case "VER":
                    driversNumbers.Add("1");
                    break;
                case "PER":
                    driversNumbers.Add("11");
                    break;
                case "HAM":
                    driversNumbers.Add("44");
                    break;
                case "RUS":
                    driversNumbers.Add("63");
                    break;
                case "LEC":
                    driversNumbers.Add("16");
                    break;
                case "SAI":
                    driversNumbers.Add("55");
                    break;
                case "LAN":
                    driversNumbers.Add("4");
                    break;
                case "RIC":
                    driversNumbers.Add("3");
                    break;
                case "ALO":
                    driversNumbers.Add("14");
                    break;
                case "OCO":
                    driversNumbers.Add("31");
                    break;
                case "GAS":
                    driversNumbers.Add("10");
                    break;
                case "TSU":
                    driversNumbers.Add("22");
                    break;
                case "MAG":
                    driversNumbers.Add("20");
                    break;
                case "MSC":
                    driversNumbers.Add("47");
                    break;
                case "LAT":
                    driversNumbers.Add("6");
                    break;
                case "ALB":
                    driversNumbers.Add("23");
                    break;
                case "VET":
                    driversNumbers.Add("5");
                    break;
                case "STR":
                    driversNumbers.Add("18");
                    break;
                case "BOT":
                    driversNumbers.Add("77");
                    break;
                case "ZHO":
                    driversNumbers.Add("24");
                    break;
                case "HUL":
                    driversNumbers.Add("27");
                    break;
                case "DEV":
                    driversNumbers.Add("45");
                    break;
                
            }
        }

        return driversNumbers;
    }
}
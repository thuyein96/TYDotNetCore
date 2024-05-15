using Newtonsoft.Json;

Console.WriteLine("Hello, World!");

string jsonStr = await File.ReadAllTextAsync("MyanmarMonths.json");
var model = JsonConvert.DeserializeObject<MainDto>(jsonStr);

foreach(var item in model.Tbl_Months)
{
    Console.WriteLine(item.MonthEn);
}

Console.ReadLine();

public class MainDto
{
    public Tbl_Months[] Tbl_Months { get; set; }
}

public class Tbl_Months
{
    public int Id { get; set; }
    public string MonthMm { get; set; }
    public string MonthEn { get; set; }
    public string FestivalMm { get; set; }
    public string FestivalEn { get; set; }
    public string Description { get; set; }
    public string Detail { get; set; }
}




using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace TYDotNetCore.RestApiWithNLayer.Features.MyanmarMonths
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyanmarMonthsController : ControllerBase
    {
        private async Task<MyanmarMonths> GetDataAsync()
        {
            string jsonStr = await System.IO.File.ReadAllTextAsync("MyanmarMonths.json");
            var model = JsonConvert.DeserializeObject<MyanmarMonths>(jsonStr);
            return model;
        }

        [HttpGet]
        public async Task<IActionResult> GetMonths()
        {
            var model = await GetDataAsync();
            List<MonthNames> months = model.Tbl_Months.Select(x => new MonthNames
            {
                Id = x.Id,
                MonthMm = x.MonthMm
            }).ToList();
            return Ok(months);
        }

        [HttpGet("{monthId}")]
        public async Task<IActionResult> GetDetails(int monthId)
        {
            var model = await GetDataAsync();
            var month = model.Tbl_Months.FirstOrDefault(x => x.Id == monthId);
            return Ok(month);
        }


        public class MyanmarMonths
        {
            public Tbl_Months[] Tbl_Months { get; set; }
        }

        public class MonthNames
        {
            public int Id { get; set; }
            public string MonthMm { get; set; }
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
    }
}

using Dapper.Project.Models.DTOS;
using Dapper.Project.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Dapper.Project.Controllers
{
    public class DefaultController : Controller
    {
        private readonly string _connectionString = "Server=.\\SQLEXPRESS; initial catalog=DapperDb; integrated security=true";
        private readonly IDapperService _service;

        public DefaultController(IDapperService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            await using var connection = new SqlConnection(_connectionString);

            var countryMaxCount = (await connection.QueryAsync<CountryDto>("SELECT TOP 1 CountryName, COUNT(*) AS Count FROM dbo.Airline GROUP BY CountryName ORDER BY Count DESC")).FirstOrDefault();
            var countryMinCount = (await connection.QueryAsync<CountryDto>("SELECT TOP 1 CountryName, COUNT(*) AS Count FROM dbo.Airline GROUP BY CountryName ORDER BY Count ASC")).FirstOrDefault();

            var nationalityMaxCount = (await connection.QueryAsync<NationalityDto>("SELECT TOP 1 Nationality, COUNT(*) AS Count FROM dbo.Airline GROUP BY Nationality ORDER BY Count DESC")).FirstOrDefault();
            var nationalityMinCount = (await connection.QueryAsync<NationalityDto>("SELECT TOP 1 Nationality, COUNT(*) AS Count FROM dbo.Airline GROUP BY Nationality ORDER BY Count ASC")).FirstOrDefault(); 

            var continentsMaxCount = (await connection.QueryAsync<ContinentDto>("SELECT TOP 1 Continents, COUNT(*) AS Count FROM dbo.Airline GROUP BY Continents ORDER BY Count DESC")).FirstOrDefault();
            var continentsMinCount = (await connection.QueryAsync<ContinentDto>("SELECT TOP 1 Continents, COUNT(*) AS Count FROM dbo.Airline GROUP BY Continents ORDER BY Count ASC")).FirstOrDefault();

            ViewData["countryNameMax"] = countryMaxCount.CountryName;
            ViewData["countCountryNameMax"] = countryMaxCount.Count;

            ViewData["countryNameMin"] = countryMinCount.CountryName;
            ViewData["countCountryNameMin"] = countryMinCount.Count;

            ViewData["nationalityNameMax"] = nationalityMaxCount.Nationality;
            ViewData["countNationalityNameMax"] = nationalityMaxCount.Count;

            ViewData["nationalityNameMin"] = nationalityMinCount.Nationality;
            ViewData["countNationalityNameMin"] = nationalityMinCount.Count;

            ViewData["continentsNameMax"] = continentsMaxCount.Continents;
            ViewData["countContinentsNameMax"] = continentsMaxCount.Count;

            ViewData["continentsNameMin"] = continentsMinCount.Continents;
            ViewData["countContinentsNameMin"] = continentsMinCount.Count;


            return View();
        }
       //public async Task<PartialViewResult> CountryList()
       // {

       //     var value= await _service.GetlistCountry();

       //     return PartialView(value);
       // }
    }
}

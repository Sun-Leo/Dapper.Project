using Dapper.Project.Models.DTOS;
using Dapper.Project.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
namespace Dapper.Project.Controllers
{
    public class SearchController : Controller
    {
        private readonly string _connectionString = "Server=.\\SQLEXPRESS; initial catalog=DapperDb; integrated security=true";
        private readonly IDapperService _dapperService;

        public SearchController(IDapperService dapperService)
        {
            _dapperService = dapperService;
        }
       
        public async Task<IActionResult> Index(string searchString)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = "SELECT TOP 100 * FROM dbo.Airline";


            if (!string.IsNullOrEmpty(searchString))
            {
               

                query = "SELECT * FROM dbo.Airline WHERE AirportName LIKE @SearchString";
                searchString = $"%{searchString}%";

               
            }
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var values = await connection.QueryAsync<Airline>(query, new { SearchString = searchString });

            stopwatch.Stop();
            TimeSpan time = stopwatch.Elapsed;
            ViewBag.timeSpanDapper = time.TotalSeconds.ToString();

            return View(values);
        }
    }
}

using Dapper.Project.Models.DTOS;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Dapper.Project.Services
{
    public class DapperService : IDapperService
    {
        private readonly string _connectionString = "Server=.\\SQLEXPRESS; initial catalog=DapperDb; integrated security=true";

        public async Task<List<Airline>> GetAlllistAirline()
        {
            await using var connection = new SqlConnection(_connectionString);

            var value = (await connection.QueryAsync<Airline>("select top 100 FirstName,LastName,Nationality,AirportName,Status from dbo.Airline"));
            return value.ToList();
        }

        public async Task<List<Airline>> GetlistCountry()
        {
            await using var connection = new SqlConnection(_connectionString);


            var values = (await connection.QueryAsync<Airline>("select top 6 AirportName from dbo.Airline"));
            return values.ToList();
        }

        
    }
}

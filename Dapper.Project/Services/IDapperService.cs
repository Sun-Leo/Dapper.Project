using Dapper.Project.Models.DTOS;
using System.Linq.Expressions;

namespace Dapper.Project.Services
{
    public interface IDapperService
    {
        Task<List<CountryDto>> GetlistCountry();
        Task<List<Airline>> GetAlllistAirline();
    }
}

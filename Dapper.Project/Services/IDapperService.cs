using Dapper.Project.Models.DTOS;
using System.Linq.Expressions;

namespace Dapper.Project.Services
{
    public interface IDapperService
    {
        Task<List<Airline>> GetlistCountry();
        Task<List<Airline>> GetAlllistAirline();
    }
}

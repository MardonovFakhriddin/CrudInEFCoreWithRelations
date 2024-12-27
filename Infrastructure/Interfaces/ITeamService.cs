using Domain.Entities;
using Infrastructure.ApiResponses;

namespace Infrastructure.Interfaces;

public interface ITeamService
{
    Task<Response<List<Team>>> GetAllAsync();
    Task<Response<Team>> GetByIdAsync(int id);
    Task<Response<string>> CreateAsync(Team request);
    Task<Response<string>> UpdateAsync(Team request);
    Task<Response<string>> DeleteAsync(int id);
}
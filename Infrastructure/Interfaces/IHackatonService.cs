using Domain.Entities;
using Infrastructure.ApiResponses;

namespace Infrastructure.Interfaces;

public interface IHackatonService
{
    Task<Response<List<Hackaton>>> GetAllAsync();
    Task<Response<Hackaton>> GetByIdAsync(int id);
    Task<Response<string>> CreateAsync(Hackaton request);
    Task<Response<string>> UpdateAsync(Hackaton request);
    Task<Response<string>> DeleteAsync(int id);
}
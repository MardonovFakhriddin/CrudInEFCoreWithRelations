using Domain.Entities;
using Infrastructure.ApiResponses;

namespace Infrastructure.Interfaces;

public interface IParticipantService
{
    Task<Response<List<Participant>>> GetAllAsync();
    Task<Response<Participant>> GetByIdAsync(int id);
    Task<Response<string>> CreateAsync(Participant request);
    Task<Response<string>> UpdateAsync(Participant request);
    Task<Response<string>> DeleteAsync(int id);
}
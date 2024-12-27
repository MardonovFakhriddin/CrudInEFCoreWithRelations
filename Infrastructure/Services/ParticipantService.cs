using System.Net;
using Domain.Entities;
using Infrastructure.ApiResponses;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class ParticipantService(DataContext context):IParticipantService
{
     public async Task<Response<List<Participant>>> GetAllAsync()
    {
        var products = await context.Participants.ToListAsync();
        return new Response<List<Participant>>(products);
    }

    public async Task<Response<Participant>> GetByIdAsync(int id)
    {
        var product = await context.Participants.FirstOrDefaultAsync((p => p.Id == id));
        return product == null
            ? new Response<Participant>(HttpStatusCode.NotFound, "Participant not found")
            : new Response<Participant>(product);
    }

    public async Task<Response<string>> CreateAsync(Participant request)
    {
        await context.Participants.AddAsync(request);
        var result = await context.SaveChangesAsync();
        return result == 0
            ? new Response<string>(HttpStatusCode.InternalServerError, "Participant not created")
            : new Response<string>("Participant created successfully");
    }

    public async Task<Response<string>> UpdateAsync(Participant request)
    {
        var Participant = await context.Participants.FirstOrDefaultAsync(p => p.Id == request.Id);
        if (Participant == null)
        {
            return new Response<string>(HttpStatusCode.NotFound, "Participant not found");
        }

        Participant.Name = request.Name;
        Participant.Email = request.Email;
        Participant.Role = request.Role;
        Participant.JoinDate = request.JoinDate;
        Participant.TeamId = request.TeamId;


        var result = await context.SaveChangesAsync();

        return result == 0
            ? new Response<string>(HttpStatusCode.InternalServerError, "product not updated")
            : new Response<string>("Participant updated successfully");
    }

    public async Task<Response<string>> DeleteAsync(int id)
    {
        var Participant = await context.Participants.FirstOrDefaultAsync(p => p.Id == id);
        if (Participant == null)
        {
            return new Response<string>(HttpStatusCode.NotFound, "Participant not found");
        }

        context.Remove(Participant);
        var result = await context.SaveChangesAsync();

        return result == 0
            ? new Response<string>(HttpStatusCode.InternalServerError, "Participant not deleted")
            : new Response<string>("Participant deleted successfully");
    }
}
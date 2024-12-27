using System.Net;
using Domain.Entities;
using Infrastructure.ApiResponses;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class TeamService(DataContext context) : ITeamService
{
    public async Task<Response<List<Team>>> GetAllAsync()
    {
        var products = await context.Teams.ToListAsync();
        return new Response<List<Team>>(products);
    }

    public async Task<Response<Team>> GetByIdAsync(int id)
    {
        var product = await context.Teams.FirstOrDefaultAsync((p => p.Id == id));
        return product == null
            ? new Response<Team>(HttpStatusCode.NotFound, "Team not found")
            : new Response<Team>(product);
    }

    public async Task<Response<string>> CreateAsync(Team request)
    {
        await context.Teams.AddAsync(request);
        var result = await context.SaveChangesAsync();
        return result == 0
            ? new Response<string>(HttpStatusCode.InternalServerError, "Team not created")
            : new Response<string>("Team created successfully");
    }

    public async Task<Response<string>> UpdateAsync(Team request)
    {
        var Team = await context.Teams.FirstOrDefaultAsync(p => p.Id == request.Id);
        if (Team == null)
        {
            return new Response<string>(HttpStatusCode.NotFound, "Team not found");
        }

        Team.Name = request.Name;
        Team.CreatedDate = request.CreatedDate;
        Team.HackatonId = request.HackatonId;


        var result = await context.SaveChangesAsync();

        return result == 0
            ? new Response<string>(HttpStatusCode.InternalServerError, "product not updated")
            : new Response<string>("Team updated successfully");
    }

    public async Task<Response<string>> DeleteAsync(int id)
    {
        var Team = await context.Teams.FirstOrDefaultAsync(p => p.Id == id);
        if (Team == null)
        {
            return new Response<string>(HttpStatusCode.NotFound, "Team not found");
        }

        context.Remove(Team);
        var result = await context.SaveChangesAsync();

        return result == 0
            ? new Response<string>(HttpStatusCode.InternalServerError, "Team not deleted")
            : new Response<string>("Team deleted successfully");
    }
}
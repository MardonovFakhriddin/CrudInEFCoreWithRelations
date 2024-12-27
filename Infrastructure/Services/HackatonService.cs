using System.Net;
using Domain.Entities;
using Infrastructure.ApiResponses;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class HackatonService(DataContext context) : IHackatonService
{
     public async Task<Response<List<Hackaton>>> GetAllAsync()
    {
        var products = await context.Hackatons.ToListAsync();
        return new Response<List<Hackaton>>(products);
    }

    public async Task<Response<Hackaton>> GetByIdAsync(int id)
    {
        var product = await context.Hackatons.FirstOrDefaultAsync((p => p.Id == id));
        return product == null
            ? new Response<Hackaton>(HttpStatusCode.NotFound, "Hackaton not found")
            : new Response<Hackaton>(product);
    }

    public async Task<Response<string>> CreateAsync(Hackaton request)
    {
        await context.Hackatons.AddAsync(request);
        var result = await context.SaveChangesAsync();
        return result == 0
            ? new Response<string>(HttpStatusCode.InternalServerError, "Hackaton not created")
            : new Response<string>("Hackaton created successfully");
    }

    public async Task<Response<string>> UpdateAsync(Hackaton request)
    {
        var Hackaton = await context.Hackatons.FirstOrDefaultAsync(p => p.Id == request.Id);
        if (Hackaton == null)
        {
            return new Response<string>(HttpStatusCode.NotFound, "Hackaton not found");
        }

        Hackaton.Name = request.Name;
        Hackaton.Date = request.Date;
        Hackaton.Theme = request.Theme;


        var result = await context.SaveChangesAsync();

        return result == 0
            ? new Response<string>(HttpStatusCode.InternalServerError, "product not updated")
            : new Response<string>("Hackaton updated successfully");
    }

    public async Task<Response<string>> DeleteAsync(int id)
    {
        var Hackaton = await context.Hackatons.FirstOrDefaultAsync(p => p.Id == id);
        if (Hackaton == null)
        {
            return new Response<string>(HttpStatusCode.NotFound, "Hackaton not found");
        }

        context.Remove(Hackaton);
        var result = await context.SaveChangesAsync();

        return result == 0
            ? new Response<string>(HttpStatusCode.InternalServerError, "Hackaton not deleted")
            : new Response<string>("Hackaton deleted successfully");
    }
}
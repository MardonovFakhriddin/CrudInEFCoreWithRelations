using Domain.Entities;
using Infrastructure.ApiResponses;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HackatonController(IHackatonService hackatonService)
{
    [HttpGet]
    public async Task<Response<List<Hackaton>>> GetAllAsync()
    {
        var result = await hackatonService.GetAllAsync();
        return (result);
    }

    [HttpGet("{id:int}")]
    public async Task<Response<Hackaton>> GetByIdAsync(int id)
    {
        var result = await hackatonService.GetByIdAsync(id);
        return (result);
    }

    [HttpPost]
    public async Task<Response<string>> CreateAsync(Hackaton request)
    {
        var result = await hackatonService.CreateAsync(request);
        return (result);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateAsync(Hackaton request)
    {
        var result = await hackatonService.UpdateAsync(request);
        return (result);
    }
    [HttpDelete]
    public async Task<Response<string>> DeleteAsync(int id)
    {
        var result = await hackatonService.DeleteAsync(id);
        return (result);
    }
}
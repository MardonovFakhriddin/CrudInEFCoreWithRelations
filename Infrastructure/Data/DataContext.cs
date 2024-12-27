using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DataContext(DbContextOptions<DataContext> options):DbContext(options)
{
    public DbSet<Hackaton> Hackatons { get; set; }
    public DbSet<Participant> Participants { get; set; }
    public DbSet<Team> Teams { get; set; }
}
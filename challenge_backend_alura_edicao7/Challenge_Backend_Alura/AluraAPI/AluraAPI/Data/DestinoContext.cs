using AluraAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AluraAPI.Data;

public class DestinoContext : DbContext
{
    public DestinoContext(DbContextOptions<DestinoContext> opts)
        : base(opts)
    {
        
    }

    public DbSet<Destino> Destinos { get; set; }
}

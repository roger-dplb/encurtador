using encurtador.Models;
using Microsoft.EntityFrameworkCore;

namespace encurtador.Infra;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Links> Links { get; set; }
}
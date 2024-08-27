using ApiCarros.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCarros.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<CarroModel> Carros { get; set; }
    }
}

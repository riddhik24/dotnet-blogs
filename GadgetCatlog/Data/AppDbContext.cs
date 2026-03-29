using Microsoft.EntityFrameworkCore;
using GadgetCatlog.Models;
namespace GadgetCatlog.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options){}
        
        public DbSet<Catlog> Catlog {get;set;}
    }
}
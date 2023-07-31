using LAtelier.Catmash.Domain;
using Microsoft.EntityFrameworkCore;

namespace LAtelier.Catmash.Infrastructure
{
    public class CatmashDbContext : DbContext
    {
        public CatmashDbContext(DbContextOptions<CatmashDbContext> options)
            :base(options) { }

        public DbSet<Cat> Cats { get; set; }
    }
}
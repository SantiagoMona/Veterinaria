using Microsoft.EntityFrameworkCore;
using riwivet.Models;

namespace riwivet.Data
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options):base(options){}
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Vet> Vets { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        
    }
}
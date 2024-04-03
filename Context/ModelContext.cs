using Microsoft.EntityFrameworkCore;
using Productify.Models;

namespace Productify.Context
{
    public class ModelContext : DbContext
    {

        public ModelContext(DbContextOptions<ModelContext> options)
           : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Produto> Produtos { get; set; }
    }
}

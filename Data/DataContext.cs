using Arvefordeleren.Models;
using Microsoft.EntityFrameworkCore;

namespace Arvefordeleren.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Asset> Assets { get; set; }
        public DbSet<Testator> Testators { get; set; }
    }
}

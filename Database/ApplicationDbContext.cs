using Microsoft.EntityFrameworkCore;
using Store.ItemManager.Models;

namespace Store.ItemManager.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }

        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}

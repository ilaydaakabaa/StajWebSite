using Microsoft.EntityFrameworkCore;
using WebAppBaslangc.Entities;
using WebAppBaslangc.Models;

namespace WebAppBaslangc
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<UsersA> UsersA { get; set; }
        public DbSet<Biycle> bicyles { get; set; }  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UsersA>()
                .HasIndex(u => u.eMail)
                .IsUnique();

            modelBuilder.Entity<UsersA>()
                .HasIndex(u => u.userName)
                .IsUnique();
     
        }
    }
    
}

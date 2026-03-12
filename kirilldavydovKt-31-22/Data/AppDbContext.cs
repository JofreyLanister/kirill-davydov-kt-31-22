using System.Text.RegularExpressions;
using kirilldavydovKt_31_22.Models;
using Microsoft.EntityFrameworkCore;

namespace kirilldavydovKt_31_22.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<kirilldavydovKt_31_22.Models.Group> Groups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
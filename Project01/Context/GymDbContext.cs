using Microsoft.EntityFrameworkCore;
using MVCProject1.Context.Configuration;
using MVCProject1.Models;

namespace MVCProject1.Context;

public class GymDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server = (localdb)\\MSSQLLocalDB; Database = GymDbC46; Trusted_Connection = True; TrustServerCertificate = true;");
    }
    public DbSet<Plan> Plans { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PlanConfiguration());
    }

}

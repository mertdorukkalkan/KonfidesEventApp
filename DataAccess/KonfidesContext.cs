using DataAccess.Domain;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess;

public class KonfidesContext : IdentityDbContext<ApplicationUser,ApplicationRole ,int>
{
    protected readonly IConfiguration Configuration;
    public KonfidesContext( DbContextOptions<KonfidesContext> options) : base(options)
    {
        //AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(x => { x.ToTable("Addresses"); });
        modelBuilder.Entity<Category>(x => { x.ToTable("Categories")
            .HasIndex(e=>e.CategoryName).IsUnique(); });
        modelBuilder.Entity<City>(x => { x.ToTable("City")
            .HasIndex(e=>e.CityName).IsUnique(); });
        modelBuilder.Entity<Event>(x => { x.ToTable("Events"); });
        modelBuilder.Entity<Status>(x => { x.ToTable("Status"); });
        modelBuilder.Entity<Ticket>(x => { x.ToTable("Tickets"); });
       
        base.OnModelCreating(modelBuilder);
    }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<ApplicationRole> ApplicationRoles { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Status> Status { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    
}
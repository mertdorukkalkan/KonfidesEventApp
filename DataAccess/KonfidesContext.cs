using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess;

public class KonfidesContext : IdentityDbContext<ApplicationUser>
{
    protected readonly IConfiguration Configuration;
    public KonfidesContext( DbContextOptions<KonfidesContext> options) : base(options)
    {
        //AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>(x => { x.ToTable("blogs"); });
       
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Blog> Blogs { get; set; }
    
}
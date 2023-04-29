using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ShoeExplorerModel;

public partial class ShoeExplorerContext : IdentityDbContext<ShoeExplorerUser>
{
    public ShoeExplorerContext()
    {
    }

    public ShoeExplorerContext(DbContextOptions<ShoeExplorerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Shoe> Shoes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationBuilder builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile("appsettings.development.json", optional: true);

        IConfigurationRoot configuration = builder.Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
    }
        //=> optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ShoeExplorer;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.Property(e => e.BrandName).IsFixedLength();
        });
        /*
        modelBuilder.Entity<Shoe>(entity =>
        {
            entity.Property(e => e.Brand).IsFixedLength();
            entity.Property(e => e.Model).IsFixedLength();

            entity.HasOne(d => d.BrandNavigation).WithMany(p => p.Shoes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Shoes_Brands");
        });*/

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

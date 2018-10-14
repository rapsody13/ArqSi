using Microsoft.EntityFrameworkCore;

namespace ClosetApi.Models
{
    public class ClosetContext : DbContext
    {
        public ClosetContext(DbContextOptions<ClosetContext> options)
            : base(options)
        {
        }
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Material> Materials {get; set;}
        public DbSet<Finish> Finishes {get; set;}
        public DbSet<Category> Categories {get; set;}
        public DbSet<Measurement> Measurements {get; set;}
    
       
       protected override void OnModelCreating(ModelBuilder modelBuilder){
        //    modelBuilder.Entity<ProductMeasurement>()
        //    .HasKey(pm => new {pm.ProductId, pm.MeasurementId});

        //    modelBuilder.Entity<ProductMeasurement>()
        //    .HasOne(pm => pm.Product)
        //    .WithMany(p => p.ProductMeasurements)
        //    .HasForeignKey(pm => pm.ProductId);

        //     modelBuilder.Entity<ProductMeasurement>()
        //    .HasOne(pm => pm.Measurement)
        //    .WithMany(m => m.ProductMeasurements)
        //    .HasForeignKey(pm => pm.MeasurementId);

           modelBuilder.Entity<ProductMaterial>()
           .HasKey(prma => new {prma.ProductId, prma.MaterialId});

           modelBuilder.Entity<ProductMaterial>()
           .HasOne(prma => prma.Product)
           .WithMany(pr => pr.ProductMaterials)
           .HasForeignKey(prma => prma.ProductId);

           modelBuilder.Entity<ProductMaterial>()
           .HasOne(prma => prma.Material)
           .WithMany(ma => ma.ProductMaterials)
           .HasForeignKey(prma => prma.MaterialId);
       }

    }
}
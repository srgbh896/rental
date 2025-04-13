namespace RentalAPP.Infrastructure.Persistence;

using RentalAPP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class RentalDbContext(DbContextOptions<RentalDbContext> options) : DbContext(options)
{
    public DbSet<CarEntity> Cars => Set<CarEntity>();
    public DbSet<CustomerEntity> Customers => Set<CustomerEntity>();
    public DbSet<RentalEntity> Rentals => Set<RentalEntity>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<CarEntity>(entity =>
        {
            entity.Property(c => c.Brand).IsRequired().HasMaxLength(100);
            entity.Property(c => c.Model).IsRequired().HasMaxLength(100);
            entity.Property(c => c.BasePricePerDay).HasPrecision(10, 2);
        });

        modelBuilder.Entity<CustomerEntity>(entity =>
        {
            entity.Property(c => c.FullName).IsRequired().HasMaxLength(200);
        });

        modelBuilder.Entity<RentalEntity>(entity =>
        {
            entity.HasOne(r => r.Car)
                  .WithMany()
                  .HasForeignKey(r => r.CarId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(r => r.Customer)
                  .WithMany(c => c.Rentals)
                  .HasForeignKey(r => r.CustomerId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.Property(r => r.PaidAmount).HasPrecision(10, 2);
            entity.Property(r => r.ExtraCharge).HasPrecision(10, 2);
        });
    }
}

using DodoBed.Manufacturing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DodoBed.Manufacturing.SqlPersistence
{
    public class AddressTypeConfigurations : IEntityTypeConfiguration<DigitalAddressType>
    {
        /**
 * This is where all the configurations for the entities are placed.
 * These configurations are a way to step away from data annotations 
 * being applied to the domain entities. Since, the core should remain as
 * agnostic as possible.
 * These configurations would not take effect if ApplyConfigurationsFromAssembly
 * is not invoked from OnModelCreating method.
 */
        public void Configure(EntityTypeBuilder<DigitalAddressType> builder)
        {
            builder.Property(e => e.Name)
                .HasConversion<int>();
        }
    }

    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(e => e.CreatedDate)
                 .HasDefaultValue(DateTime.Now);
            builder.Property(e => e.LastModifiedDate)
                  .HasDefaultValue(DateTime.Now);
            builder.HasKey(e => e.ItemId);

        }
    }

    public class ToolConfiguration : IEntityTypeConfiguration<Tool>
    {

        public void Configure(EntityTypeBuilder<Tool> builder)
        {
            builder.Property(e => e.CreatedDate)
               .HasDefaultValue(DateTime.Now);
            builder.Property(e => e.LastModifiedDate)
                  .HasDefaultValue(DateTime.Now);
            builder.HasKey(e => e.ItemId);
        }
    }

    public class ManufacturedProductInventoryConfiguration : IEntityTypeConfiguration<ManufacturedProductInventory>
    {
        public void Configure(EntityTypeBuilder<ManufacturedProductInventory> builder)
        {
            builder.HasKey(e => e.ManufacturedProductInventoryId);
        }
    }

   public  class ManufacturingShopProcessorStateConfiguration : IEntityTypeConfiguration<ManufacturingShopProcessorState>
    {
        public void Configure(EntityTypeBuilder<ManufacturingShopProcessorState> builder)
        {
            builder.Property(e => e.StateName)
                .HasConversion<string>();
        }
    }
    class DigitalAddressTypeConfiguration : IEntityTypeConfiguration<DigitalAddressType>
    {
        public void Configure(EntityTypeBuilder<DigitalAddressType> builder)
        {
            builder.Property(e => e.Name)
                .HasConversion<string>();
        }
    }

    public class ProductionCapacityConfiguration : IEntityTypeConfiguration<ProductionCapacity>
    {
        public void Configure(EntityTypeBuilder<ProductionCapacity> builder)
        {
            builder.Property(e => e.Month)
                .HasConversion<string>();
        }
    }

    class ObsoleteManufacturedProductConfiguration : IEntityTypeConfiguration<ObsoleteManufacturedProduct>
    {
        public void Configure(EntityTypeBuilder<ObsoleteManufacturedProduct> builder)
        {
            builder.HasKey(e => e.ObsoleteManufacturedProductId);
        }
    }

}

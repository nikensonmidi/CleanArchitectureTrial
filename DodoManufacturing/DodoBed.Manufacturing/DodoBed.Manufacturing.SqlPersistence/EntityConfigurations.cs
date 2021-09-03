using DodoBed.Manufacturing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


}

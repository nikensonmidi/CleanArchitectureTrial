using GloboTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Persistence
{
    /**
     * This is where all the configurations for the entities are placed.
     * These configurations are a way to step away from data annotations 
     * being applied to the domain entities. Since, the core should remain as
     * agnostic as possible.
     * These configurations would not take effect if ApplyConfigurationsFromAssembly
     * is not invoked from OnModelCreating method.
     */

    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

        }
    }
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(e => e.CReatedDate)
                 .HasDefaultValue(DateTime.Now);
        }
    }

}

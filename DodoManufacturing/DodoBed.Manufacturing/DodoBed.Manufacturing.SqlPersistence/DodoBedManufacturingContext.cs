using DodoBed.Manufacturing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DodoBed.Manufacturing.SqlPersistence
{
    public class DodoBedManufacturingContext:DbContext
    {
        public DodoBedManufacturingContext(DbContextOptions<DodoBedManufacturingContext> options):base(options)
        {

        }
        //Was used to initialize the database
        //public class AppDbContextFactory : IDesignTimeDbContextFactory<GloboTicketDBcontext>
        //{
        //    public GloboTicketDBcontext CreateDbContext(string[] args)
        //    {
        //        var optionsBuilder = new DbContextOptionsBuilder<GloboTicketDBcontext>();
        //        optionsBuilder.UseSqlServer("");

        //        return new GloboTicketDBcontext(optionsBuilder.Options);
        //    }
        //}

        public DbSet<Product> Products { get; set; }
        public DbSet<Tool> Tools { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<DigitalAddress> DigitalAddresses { get; set; }
        public DbSet<DigitalAddressType> DigitalAddressTypes { get; set; }


    }

}

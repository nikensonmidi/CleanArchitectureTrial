using DodoBed.Manufacturing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
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
        public class AppDbContextFactory : IDesignTimeDbContextFactory<DodoBedManufacturingContext>
        {
            public DodoBedManufacturingContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<DodoBedManufacturingContext>();
                optionsBuilder.UseSqlServer("Data source = DESKTOP-OUHGCH1\\MSSQLSERVER01; initial catalog=DodoManufacturing; Integrated Security=True");
                
                return new DodoBedManufacturingContext(optionsBuilder.Options);
            }
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Tool> Tools { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<DigitalAddress> DigitalAddresses { get; set; }
        public DbSet<DigitalAddressType> DigitalAddressTypes { get; set; }
        public DbSet<Dimension> Dimensions { get; set; }
        public DbSet<ProductLocation> ProductLocations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DodoBedManufacturingContext).Assembly);
            base.OnModelCreating(modelBuilder); 
        }
    }

}

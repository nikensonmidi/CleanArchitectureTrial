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
                optionsBuilder.UseSqlServer();
                
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
        public DbSet<Note> Notes { get; set; }
        public DbSet<ManufacturingShop> ManufacturingShops { get; set; }
        public DbSet<ManufacturingShopSchedule> ManufacturingShopSchedules { get; set; }
        public DbSet<ManufacturedProduct> ManufacturedProducts { get; set; }
        public DbSet<ManufacturingShopProcessor> ManufacturingShopProcessors { get; set; }
        public DbSet<ManufacturingShopProcessorState> ManufacturingShopProcessorStates { get; set; }
        public DbSet<Cost> Costs { get; set; }
        public DbSet<ActivityBasedCost> ActivityBasedCosts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeePosition> EmployeePositions { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<ManufacturedProductAssembly> ManufacturedProductAssemblies { get; set; }
        public DbSet<ProductDesignDocument> ProductDesignDocuments { get; set; }
        public DbSet<ManufacturedProductInventory> ManufacturedProductInventories { get; set; }

        public DbSet<ObsoleteManufacturedProduct> ObsoleteManufacturedProducts { get; set; }
        public DbSet<ManufacturingShopScheduleLog> ManufacturingShopScheduleLogs { get; set; }
        public DbSet<ProductionCapacity> ProductionCapacities { get; set; }
        public DbSet<MachineTool> MachineTools { get; set; }
        public DbSet<ManufacturedProductCreated> CreatedManufacturedProducts { get; set; }
        public DbSet<ManufacturingShopProcessorActivity> ManufacturingShopProcessorActivities { get; set; }

        public DbSet<ManufacturedProductScheduled> ManufacturedProductScheduled { get; set; }
        public DbSet<ProductManufacturingShop> ProductManufacturingShops { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DodoBedManufacturingContext).Assembly);
            base.OnModelCreating(modelBuilder); 
        }
    }

}

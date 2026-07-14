using DodoBed.Manufacturing.Domain.Common;
using System;
using System.Collections.Generic;

namespace DodoBed.Manufacturing.Domain.Entities
{
    public class Product : Item
    {
        public ICollection<Note> Notes { get; set; }
        public string InHouseName { get; set; }
        public string Code { get; set; }
        public Cost ProductCost { get; set; }
        public Price PorductPrice { get; set; }
        public ICollection<Supplier> Suppliers { get; set; }

    }


    public class ManufacturedProduct
    {
        public int ManufacturedProductId { get; set; }
        public Product Product { get; set; }
        public Dimension Dimension { get; set; }
        public double AverageAssembledTimeInSec { get; set; }
        public double LowestAssembledTimeInSec { get; set; }
        public double HighestAssembledTimeInSec { get; set; }
        public double AverageDailyQuota { get; set; }
        public ICollection<ProductionCapacity> ProductionCapacities { get; set; }
        public int LowestQuota { get; set; }
        public int HighestQuota { get; set; }
        public ICollection<ManufacturedProductAssembly> ProductComponents { get; set; }
        public ICollection<ProductDesignDocument> DesignDocuments { get; set; }
        public ICollection<ProductManufacturingShop> ProductShops { get; set; }

    }
    public class ManufacturedProductCreated
    {
        public long ManufacturedProductCreatedId { get; set; }
        public ManufacturedProduct ManufacturedProduct { get; set; }
    }

    public class ManufacturedProductScheduled
    {
        public long ManufacturedProductScheduledId { get; set; }
        public ManufacturedProductInventory InventoriedProduct { get; set; }
    }

    public class ManufacturedProductAssembly
    {
        public long ManufacturedProductAssemblyId { get; set; }
        public Product Assembly { get; set; }
        public double QuantityNeeded { get; set; }
        public ICollection<ManufacturedProductAssembly> ProductComponents { get; set; }

    }

    public class ProductDesignDocument : Item
    {
        public long ProductDesignDocumentId { get; set; }
        public Employee Author { get; set; }
        public string FileLocation { get; set; }
    }
    public class ProductManufacturingShop
    {
        public long ProductManufacturingShopId { get; set; }
        public ManufacturingShop ManufacturingShop { get; set; }
    }
    public class ManufacturedProductInventory
    {
        public long ManufacturedProductInventoryId { get; set; }
        public ManufacturedProduct Product { get; set; }
        public double QuantityUsed { get; set; }
        public double CurrentQuantityOnHand { get; set; }//Should be readonly
        public double OrderPoint { get; set; }//if OrderPoint is more than qty on hand than it is stocked 
        public DateTime TransactionDate { get; set; }

    }

   
    public class ObsoleteManufacturedProduct
    {
        public int ObsoleteManufacturedProductId { get; set; }
        public Product Product { get; set; }
        public DateTime StatusChangeDate { get; set; }
        public Employee StatusChangeBy { get; set; }
    }

  
   


}

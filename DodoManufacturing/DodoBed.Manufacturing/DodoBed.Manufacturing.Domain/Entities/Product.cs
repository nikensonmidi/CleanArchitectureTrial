using DodoBed.Manufacturing.Domain.Common;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DodoBed.Manufacturing.Domain.Entities
{
    public class Product : Item
    {
        public string Notes { get; set; }
        public string InHouseName { get; set; }
        public Cost ProductCost { get; set; }

    }

   
    public class ManufacturedProduct : Product
    {
        public Dimension Dimension { get; set; }
        public double AverageAssembledTimeInSec { get; set; }
        public double LowestAssembledTime { get; set; }
        public double HighestAssembledTime { get; set; }
        public double AverageDailyQuota { get; set; }
        public IEnumerable<ProductionCapacity> ProductionCapacities { get; set; }
        public int LowestQuota { get; set; }
        public int HighestQuota { get; set; }
        public IEnumerable<ManufacturedProductAssembly> ProductComponents { get; set; }
        public IEnumerable<ProductDesignDocument> DesignDocuments { get; set; }
    }

    public class ManufacturedProductAssembly:Product
    {
        public double QuantityNeeded { get; set; }
        public double? QuantityUsed { get; set; }
    }

    public class ProductDesignDocument:Item
    {
        public Employee Author { get; set; }
        public string FileLocation { get; set; }
    }




}

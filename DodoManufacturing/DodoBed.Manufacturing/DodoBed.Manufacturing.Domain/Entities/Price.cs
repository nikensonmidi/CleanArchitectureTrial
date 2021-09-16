using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DodoBed.Manufacturing.Domain.Entities
{
    public class Price
    {
        public int PriceId { get; set; }
        public decimal ListPrice { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LowestRebatePrice { get; set; }
        public decimal BundlePrice { get; set; }
        public decimal PurchasingPrice { get; set; }
    }
}

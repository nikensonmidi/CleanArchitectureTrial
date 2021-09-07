using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DodoBed.Manufacturing.Domain.Entities
{
    public class ProductLocation:StorageLocation
    {
        public int ProductLocationId { get; set; }
        public Product Product { get; set; }
    }
}

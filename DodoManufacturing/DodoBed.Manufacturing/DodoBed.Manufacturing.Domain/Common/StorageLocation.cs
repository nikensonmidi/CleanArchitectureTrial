using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DodoBed.Manufacturing.Domain.Entities
{
    public class StorageLocation
    {
        public int StorageLocationID { get; set; }
        public int BuildingNumber { get; set; }
        public int SectionNumber { get; set; }
        public int AisleNumber { get; set; }
        public int ShelfNumber { get; set; }
        public string Barcode { get; set; }
    }
}

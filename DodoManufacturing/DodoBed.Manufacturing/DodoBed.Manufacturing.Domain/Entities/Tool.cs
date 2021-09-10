using System;
using System.Collections.Generic;

namespace DodoBed.Manufacturing.Domain.Entities
{
    public class Tool : Item
    {
        public string ManufacturerId { get; set; }
        public ICollection<Supplier> Suppliers { get; set; }

    }
    public class MachineTool
    {
        public int MachineToolId { get; set; }
        public Tool Tool { get; set; }
        public StorageLocation Location { get; set; }
        public Dimension Size { get; set; }
        public DateTime LastMaintenanceDate { get; set; }
        public int MaintenanceFrequencyInDays { get; set; }
    }
}

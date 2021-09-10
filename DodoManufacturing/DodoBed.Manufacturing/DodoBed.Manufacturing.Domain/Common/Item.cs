using DodoBed.Manufacturing.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DodoBed.Manufacturing.Domain.Entities
{
    public class Item:AuditableEntity
    {
        public long ItemId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
    }
}

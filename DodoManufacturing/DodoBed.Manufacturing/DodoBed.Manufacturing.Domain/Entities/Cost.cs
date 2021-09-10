using DodoBed.Manufacturing.Domain.Common;
using System.Collections.Generic;

namespace DodoBed.Manufacturing.Domain.Entities
{
    public class Cost:AuditableEntity
    {
        public long CostId { get; set; }
        public IEnumerable<ActivityBasedCost> ActivityBasedCost { get; set; }
    }

    public class ActivityBasedCost
    {
        public int ActivityBasedCostId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
    }
}
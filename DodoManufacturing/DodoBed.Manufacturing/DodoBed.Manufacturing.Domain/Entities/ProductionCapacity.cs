using System.Collections.Generic;

namespace DodoBed.Manufacturing.Domain.Entities
{
    public class ProductionCapacity
    {
        public long ProductionCapacityId { get; set; }
        public Month Month { get; set; }
        public int Year { get; set; }
        public double AmountProduced { get; set; }
        public double AmountProjected { get; set; }
        public IEnumerable<Note> Notes { get; set; }
    }

    public enum Month
    {
        January,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December

    }


}
using System.Collections.Generic;

namespace DodoBed.Manufacturing.Domain.Entities
{
    //https://www.sisense.com/blog/calculate-mtd-qtd-ytd/
    public class ProductionCapacity
    {
        public long ProductionCapacityId { get; set; }
        public Month Month { get; set; }
        public int Year { get; set; }
        public double AmountProduced { get; set; }
        public double AmountProjected { get; set; }
        public ICollection<Note> Notes { get; set; }
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
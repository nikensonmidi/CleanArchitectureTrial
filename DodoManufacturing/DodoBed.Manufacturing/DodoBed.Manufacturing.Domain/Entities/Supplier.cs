using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DodoBed.Manufacturing.Domain.Entities
{
    public class Supplier
    {
        public long SupplierId { get; set; }
        public string Name { get; set; }
        public ICollection<Contact> Contacts { get; set; }
    }
}

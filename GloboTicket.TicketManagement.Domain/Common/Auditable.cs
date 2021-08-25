using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Domain.Common
{
    /// <summary>
    /// This entity is created for auditing all entities  that can be tracked
    /// </summary>
    public class AuditableEntity
    {
        public string CreatedBy { get; set; }
        public DateTime CReatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}

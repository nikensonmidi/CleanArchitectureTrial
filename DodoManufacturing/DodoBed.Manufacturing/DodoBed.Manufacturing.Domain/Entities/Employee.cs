using DodoBed.Manufacturing.Domain.Common;
using System;

namespace DodoBed.Manufacturing.Domain.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateHired { get; set; }
        public DateTime LastDateOfEmployment { get; set; }
        public EmployeePosition Position { get; set; }
    }

    public class EmployeePosition:AuditableEntity
    {
        public int EmployeePositionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
    }

  
  
}
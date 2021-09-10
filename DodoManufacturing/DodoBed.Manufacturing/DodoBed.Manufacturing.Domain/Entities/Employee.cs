using System;

namespace DodoBed.Manufacturing.Domain.Entities
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateHired { get; set; }
        public DateTime LastDateOfEmployment { get; set; }
    }
}
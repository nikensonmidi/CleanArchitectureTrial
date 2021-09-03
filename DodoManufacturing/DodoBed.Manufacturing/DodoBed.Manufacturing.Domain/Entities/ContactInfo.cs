using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DodoBed.Manufacturing.Domain.Entities
{
    public class Address
    {
        public long AddressId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }

    public class DigitalAddress
    {
        public int DigitalAddressId { get; set; }
        public DigitalAddressType DigitalAddressType { get; set; }

    }
    public enum DigitalAddressTypeName
    {
        Email,
        Twiter,
        Facebook
    }
    public class DigitalAddressType
    {
        public int DigitalAddressTypeId { get; set; }
        public DigitalAddressTypeName Name { get; set; }
        public string Value { get; set; }
    }
    public class Contact
    {
        public long ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public ICollection<Address> ContactAddresses { get; set; }
        public ICollection<DigitalAddress> DigitalAddresses { get; set; }
    }
}

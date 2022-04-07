using System;
using System.Collections.Generic;

namespace RestAPI.Models
{
    public partial class Address
    {
        public Address()
        {
            Buildings = new HashSet<Building>();
            Customers = new HashSet<Customer>();
        }

        public long Id { get; set; }
        public string? TypeOfAddress { get; set; }
        public string? Status { get; set; }
        public string? Entity { get; set; }
        public string? NumberStreet { get; set; }
        public string? SuiteApartment { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? Lat { get; set; }
        public string? Lng { get; set; }

        public virtual ICollection<Building> Buildings { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}

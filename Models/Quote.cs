using System;
using System.Collections.Generic;

namespace RestAPI.Models
{
    public partial class Quote
    {
        public long Id { get; set; }
        public string? Department { get; set; }
        public string? NumberOfFloors { get; set; }
        public string? NumberOfCompanies { get; set; }
        public string? NumberOfBasements { get; set; }
        public string? NumberOfParkingSpots { get; set; }
        public string? NumberOfElevators { get; set; }
        public string? NumberOfCorporations { get; set; }
        public string? MaximumOccupancy { get; set; }
        public string? NumberOfApartments { get; set; }
        public string? BusinessHours { get; set; }
        public string? ServiceGrade { get; set; }
        public string? ElevatorAmount { get; set; }
        public string? ElevatorUnitPrice { get; set; }
        public string? ElevatorTotalPrice { get; set; }
        public string? InstallationFees { get; set; }
        public string? FinalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? DateCreated { get; set; }
        public string? CompanyName { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactName { get; set; }
    }
}

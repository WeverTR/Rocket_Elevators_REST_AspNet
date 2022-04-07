using System;
using System.Collections.Generic;

namespace RestAPI.Models
{
    public partial class Building
    {
        public Building()
        {
            Batteries = new HashSet<Battery>();
            BuildingDetails = new HashSet<BuildingDetail>();
            Interventions = new HashSet<Intervention>();
        }

        public long Id { get; set; }
        public string? BuildingAdministratorName { get; set; }
        public string? BuildingAdministratorEmail { get; set; }
        public string? BuildingAdministratorPhone { get; set; }
        public string? TechContactName { get; set; }
        public string? TechContactEmail { get; set; }
        public string? TechContactPhone { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public long? CustomerId { get; set; }
        public long? AddressId { get; set; }

        public virtual Address? Address { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual ICollection<Battery> Batteries { get; set; }
        public virtual ICollection<BuildingDetail> BuildingDetails { get; set; }
        public virtual ICollection<Intervention> Interventions { get; set; }
    }
}

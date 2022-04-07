using System;
using System.Collections.Generic;

namespace RestAPI.Models
{
    public partial class Elevator
    {
        public Elevator()
        {
            Interventions = new HashSet<Intervention>();
        }

        public long Id { get; set; }
        public string? SerialNumber { get; set; }
        public string? Model { get; set; }
        public string? BuildingType { get; set; }
        public string? Status { get; set; }
        public string? CommissionDate { get; set; }
        public string? LastInspectionDate { get; set; }
        public string? CertificateOfInspection { get; set; }
        public string? Information { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public long? ColumnId { get; set; }

        public virtual Column? Column { get; set; }
        public virtual ICollection<Intervention> Interventions { get; set; }
    }
}

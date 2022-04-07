using System;
using System.Collections.Generic;

namespace RestAPI.Models
{
    public partial class Battery
    {
        public Battery()
        {
            Columns = new HashSet<Column>();
            Interventions = new HashSet<Intervention>();
        }

        public long Id { get; set; }
        public string? BuildingType { get; set; }
        public string? Status { get; set; }
        public string? CommissionDate { get; set; }
        public string? LastInspectionDate { get; set; }
        public string? CertificateOfOperations { get; set; }
        public string? Information { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public long? BuildingId { get; set; }
        public long? EmployeeId { get; set; }

        public virtual Building? Building { get; set; }
        public virtual Employee? Employee { get; set; }
        public virtual ICollection<Column> Columns { get; set; }
        public virtual ICollection<Intervention> Interventions { get; set; }
    }
}

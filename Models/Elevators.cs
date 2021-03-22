using System;
using System.Collections.Generic;

namespace Rocket_Elevators_Rest_API.Models
{
    public partial class Elevators
    {
        public long Id { get; set; }
        public string SerialNumber { get; set; }
        public string Model { get; set; }
        public string Status { get; set; }
        public DateTime DateOfCommissioning { get; set; }
        public DateTime DateOfLastInspection { get; set; }
        public string CertificateOfInspection { get; set; }
        public string Information { get; set; }
        public string Notes { get; set; }
        public long? ColumnId { get; set; }
        public string ElevatorType { get; set; }

        public virtual Columns Column { get; set; }
    }
}

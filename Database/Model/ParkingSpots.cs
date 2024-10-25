using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Database.Model
{
    public class ParkingSpots
    {
        public int Id { get; set; }
        public string? Location { get; set; }
        public string? Name { get; set; }
        public bool IsAviable { get; set; }
        public int? AssignedTo { get; set; }
        public DateOnly? AvialableFrom { get; set; }
        public DateOnly? AvialableUntil { get; set; }

        public Users? users { get; set; }

        public ICollection<ParkingRequests>? parkingRequests { get; set; }
        public ICollection<ParkingAuditLogs>? parkingAuditLogs { get; set; }


    }

}
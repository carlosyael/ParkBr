using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Database.Model
{
    public class ParkingAuditLogs
    {
        public int Id { get; set; }
        public string? Action { get; set; }
        public int? ParkingSpot_Id { get; set; }
        public int? User_Id { get; set; }
        public DateTime ActionDate { get; set; }
        public Users? Users { get; set; }
        public ParkingSpots? ParkingSpots { get; set; }


    }
}
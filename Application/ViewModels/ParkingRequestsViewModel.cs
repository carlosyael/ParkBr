using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class ParkingRequestsViewModel
    {
        public int Id { get; set; }
        public int? User_Id { get; set; }
        public int? ParkingSpot_Id { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DecisionDate { get; set; }
        public string? Status { get; set; }
        public string? ReviewedBy { get; set; }
    }
}

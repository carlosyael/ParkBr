using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SaveViewModel
{
    public class SaveParkingRequestViewModel
    {
        public int Id { get; set; }
        public int? User_Id { get; set; }
        public int? ParkingSpot_Id { get; set; }
        public DateTime RequestDate { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public DateTime EndDate { get; set; }
        public DateTime DecisionDate { get; set; }
        public string? Status { get; set; }
        public string? ReviewedBy { get; set; }
    }
}

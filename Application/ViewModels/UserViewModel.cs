using Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public int? ParkAssingned { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Password { get; set; }
        public DateTime CreateDate { get; set; }
        public int Role_Id { get; set; }
        public string? RoleName { get; set; }
        public ParkingSpots? ParkingSpots { get; set; }

        List<ParkingSpotsViewModel> Spots { get; set; }


    }
}

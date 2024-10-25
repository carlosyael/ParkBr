using Application.ViewModels;
using Database.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SaveViewModel
{
    public class SaveUsersViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Email Requerido")]
        public string? Email { get; set; }
        public int? ParkAssingned { get; set; }
        [Required(ErrorMessage = "FirstName Requerido")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "LastName Requerido")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Pasword Requerido")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Pasword Requerido")]
        [Compare("Password", ErrorMessage ="Contrase;as no coinciden")]
        public string ConfirmPassword { get; set; }
        public DateTime CreateDate { get; set; }
        public int Role_Id { get; set; }
        public string? RoleName { get; set; }

        public LParkingSpots LParkingSpots= LParkingSpots.GetInstance();

    }
}

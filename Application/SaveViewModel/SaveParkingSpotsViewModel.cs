using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SaveViewModel
{
    public class SaveParkingSpotsViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string? Location { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string? Name { get; set; }
        public bool IsAviable { get; set; }

        public int? AssignedTo { get; set; }
        [Required(ErrorMessage = "Usuario ya con parqueo asignado")]
        public DateOnly? AvialableFrom { get; set; }
        public DateOnly? AvialableUntil { get; set; }

        public LUsers lUsers=LUsers.GetInstance();
    }
}

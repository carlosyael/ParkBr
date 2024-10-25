using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class ParkingSpotsViewModel
    {

        public int Id { get; set; }
        public string? Location { get; set; }
        public string? Name { get; set; }
        public bool IsAviable { get; set; }
        public int? AssignedTo { get; set; }
        public DateOnly? AvialableFrom { get; set; }
        public DateOnly? AvialableUntil { get; set; }

    }
}

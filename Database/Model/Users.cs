using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Database.Model
{
    public class Users
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
        public ICollection<ParkingRequests>? parkingRequests { get; set; }
        public ICollection<ParkingAuditLogs>? parkingAuditLogs { get; set; }
        public List<Users> ObtenerDatosDePrueba()
        {
            return
        [
            new() {
                    Id = 1,
                    FirstName = "user1",
                    Password = "password1",
                    CreateDate = DateTime.Now,
                    Role_Id = 0,
                    RoleName = "Admin"
                },
                new() {
                    Id = 2,
                    FirstName = "user2",
                    Password = "password2",
                    CreateDate = DateTime.Now,
                    Role_Id= 1,
                    RoleName = "User"
                }
        ];
        }
    }

}

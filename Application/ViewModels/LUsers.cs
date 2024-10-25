using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModels;
namespace Application.ViewModels
{
    public class LUsers
    {
        public List<UserViewModel> list {  get; set; }

        static private LUsers Instance { get; set; }
        private LUsers()
        {
            
        }

        public static LUsers GetInstance()
        {
            if (Instance == null)
            {
                Instance = new LUsers();
            }
            return Instance;
        }

    }
}

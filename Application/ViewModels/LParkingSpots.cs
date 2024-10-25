using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class LParkingSpots
    {
        public List<ParkingSpotsViewModel> List = new();
        static private LParkingSpots spots;

        private LParkingSpots()
        {
            
        }

        static public LParkingSpots GetInstance()
        {
            if (spots == null)
            {
                spots = new LParkingSpots();
            }
            return spots;
        }
    }
}

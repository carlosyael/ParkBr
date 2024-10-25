using Application.Repository;
using Application.SaveViewModel;
using Application.ViewModels;
using Database;
using Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class ParkingSpotsService
    {
        private readonly ParkingSpotsRepository _parkingSpotsRepository;

        public ParkingSpotsService(ApplicationContext dbContext)
        {
            _parkingSpotsRepository= new ParkingSpotsRepository(dbContext);
        }
        public async Task<List<ParkingSpotsViewModel>> GetAllViewModel()
        {
            var parkingSpotList= await _parkingSpotsRepository.GetAllAsync();
            return parkingSpotList.Select(parkingSpot => new ParkingSpotsViewModel
            {
                Id = parkingSpot.Id,
                Name = parkingSpot.Name,
                Location = parkingSpot.Location,
                IsAviable = parkingSpot.IsAviable,
                AssignedTo = parkingSpot.AssignedTo,
                AvialableFrom = parkingSpot.AvialableFrom,
                AvialableUntil = parkingSpot.AvialableUntil
            }).ToList();
        }


        public async Task<SaveParkingSpotsViewModel> GetByIdSVM(int id)
        {
            var parkingSpot=await _parkingSpotsRepository.GetByIdAsync(id);
            SaveParkingSpotsViewModel svm = new SaveParkingSpotsViewModel();
            svm.Id = parkingSpot.Id;
            svm.Name = parkingSpot.Name;
            svm.Location = parkingSpot.Location;
            svm.IsAviable = parkingSpot.IsAviable;
            svm.AssignedTo = parkingSpot.AssignedTo;
            svm.AvialableFrom = parkingSpot.AvialableFrom;
            svm.AvialableUntil = parkingSpot.AvialableUntil;
            return svm;
        }
        public async Task Add(SaveParkingSpotsViewModel svm)
        {
            ParkingSpots parkingSpots = new();
            parkingSpots.Location = svm.Location;
            parkingSpots.Name = svm.Name;
            parkingSpots.IsAviable= svm.IsAviable;
            parkingSpots.AssignedTo= svm.AssignedTo;
            parkingSpots.AvialableFrom= svm.AvialableFrom;
            parkingSpots.AvialableUntil= svm.AvialableUntil;
            await _parkingSpotsRepository.AddAsync(parkingSpots);
        }
        public async Task Update(SaveParkingSpotsViewModel svm)
        {
            ParkingSpots parkingSpot= new();
            parkingSpot.Id = svm.Id;
            parkingSpot.Location = svm.Location;
            parkingSpot.Name = svm.Name;
            parkingSpot.IsAviable = svm.IsAviable;
            parkingSpot.AssignedTo = svm.AssignedTo;
            parkingSpot.AvialableFrom = svm.AvialableFrom;
            parkingSpot.AvialableUntil = svm.AvialableUntil;
            await _parkingSpotsRepository.UpdateAsync(parkingSpot);
        }
        public async Task Delete(int id)
        {
            var parkingSpot=await _parkingSpotsRepository.GetByIdAsync(id);
            await _parkingSpotsRepository.DeleteAsync(parkingSpot);
        }

    }
}

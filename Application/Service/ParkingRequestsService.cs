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
    public class ParkingRequestsService
    {
        internal readonly ParkingRequestsRepository _parkingRequestsRepository;
        public ParkingRequestsService(ApplicationContext dbContext) {
            _parkingRequestsRepository= new ParkingRequestsRepository(dbContext);
        }
        public async Task<List<ParkingRequestsViewModel>> GetAllViewModel()
        {
            var parkingRequestRepositoryList= await _parkingRequestsRepository.GetAllAsync();
            return parkingRequestRepositoryList.Select(parkingRequest=>new ParkingRequestsViewModel
            {
                Id = parkingRequest.Id,
                User_Id = parkingRequest.User_Id,
                ParkingSpot_Id= parkingRequest.ParkingSpot_Id,
                RequestDate = parkingRequest.RequestDate,
                StartDate = parkingRequest.StartDate,
                EndDate = parkingRequest.EndDate,
                Status = parkingRequest.Status,
                ReviewedBy = parkingRequest.ReviewedBy,
                DecisionDate = parkingRequest.DecisionDate,
            }).ToList();
        }
        public async Task<SaveParkingRequestViewModel> GetByIdSVM(int id)
        {
            var parkingRequest= await _parkingRequestsRepository.GetByIdAsync(id);
            SaveParkingRequestViewModel svm = new();
            svm.Id = parkingRequest.Id;
            svm.User_Id = parkingRequest.User_Id;
            svm.ParkingSpot_Id= parkingRequest.ParkingSpot_Id;
            svm.RequestDate = parkingRequest.RequestDate;
            svm.StartDate = parkingRequest.StartDate;
            svm.EndDate = parkingRequest.EndDate;
            svm.Status = parkingRequest.Status;
            svm.ReviewedBy = parkingRequest.ReviewedBy;
            svm.DecisionDate = parkingRequest.DecisionDate;
            return svm;
        }
        public async Task Add(SaveParkingRequestViewModel svm)
        {
            ParkingRequests parkingRequests = new ParkingRequests();
            parkingRequests.User_Id = svm.User_Id;
            parkingRequests.ParkingSpot_Id = svm.ParkingSpot_Id;
            parkingRequests.RequestDate = svm.RequestDate;
            parkingRequests.StartDate = svm.StartDate;
            parkingRequests.EndDate = svm.EndDate;
            parkingRequests.Status = svm.Status;
            parkingRequests.ReviewedBy = svm.ReviewedBy;
            parkingRequests.DecisionDate = svm.DecisionDate;
            await _parkingRequestsRepository.AddAsync(parkingRequests);
        }
        public async Task Update(SaveParkingRequestViewModel svm)
        {
            ParkingRequests parkingRequests = new ParkingRequests();
            parkingRequests.Id = svm.Id;
            parkingRequests.User_Id = svm.User_Id;
            parkingRequests.ParkingSpot_Id = svm.ParkingSpot_Id;
            parkingRequests.RequestDate = svm.RequestDate;
            parkingRequests.StartDate = svm.StartDate;
            parkingRequests.EndDate = svm.EndDate;
            parkingRequests.Status = svm.Status;
            parkingRequests.ReviewedBy = svm.ReviewedBy;
            parkingRequests.DecisionDate = svm.DecisionDate;
            await _parkingRequestsRepository.UpdateAsync(parkingRequests);
        }
        public async Task Delete(int id)
        {
            var parkinRequest= await _parkingRequestsRepository.GetByIdAsync(id);
            await _parkingRequestsRepository.DeleteAsync(parkinRequest);
        }






        
    }
}

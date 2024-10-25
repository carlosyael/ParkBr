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
    public class ParkingAuditLogsService
    {
        internal readonly ParkingAuditLogsRepository _parkinAuditLogsRepository;
        
        public ParkingAuditLogsService(ApplicationContext dbContext)
        {
            _parkinAuditLogsRepository= new ParkingAuditLogsRepository(dbContext);
        } 

        public async Task<List<ParkingAuditLogsViewModel>> GetAllViewModel()
        {
            var parkingAuditLogsList =await _parkinAuditLogsRepository.GetAllAsync();
            return parkingAuditLogsList.Select(log=>new ParkingAuditLogsViewModel
            {
                ParkingSpot_Id = log.Id,
                Id = log.Id,
                Action = log.Action,
                ActionDate = log.ActionDate,
                User_Id=log.User_Id
            }).ToList();
        }

        public async Task<SaveParkingAuditLogsViewModel> GetByIdSVM(int id)
        {
            var Log= await _parkinAuditLogsRepository.GetByIdAsync(id);
            var LogSVM = new SaveParkingAuditLogsViewModel();
            LogSVM.Id = Log.Id;
            LogSVM.Action = Log.Action;
            LogSVM.ActionDate = Log.ActionDate;
            LogSVM.ParkingSpot_Id = id;
            LogSVM.User_Id =Log.User_Id;
            return LogSVM;
        }
        public async Task Add(SaveParkingAuditLogsViewModel svm)
        {
            ParkingAuditLogs parkingAuditLogs = new();
            parkingAuditLogs.Action = svm.Action;
            parkingAuditLogs.ParkingSpot_Id=svm.ParkingSpot_Id;
            parkingAuditLogs.ActionDate = svm.ActionDate;  
            parkingAuditLogs.User_Id=svm.User_Id;
            await _parkinAuditLogsRepository.AddSync(parkingAuditLogs);
        }

        public async Task Update(SaveParkingAuditLogsViewModel svm)
        {
            ParkingAuditLogs parkingAuditLogs = new();
            parkingAuditLogs.Id = svm.Id;
            parkingAuditLogs.Action = svm.Action;
            parkingAuditLogs.ParkingSpot_Id = svm.ParkingSpot_Id;
            parkingAuditLogs.ActionDate = svm.ActionDate;
            parkingAuditLogs.User_Id = svm.User_Id;
            await _parkinAuditLogsRepository.UpdateAsync(parkingAuditLogs);

        }
        public async Task Delete(int id)
        {
            var log =await _parkinAuditLogsRepository.GetByIdAsync(id);
            await _parkinAuditLogsRepository.DeleteAsync(log);
        }

    }
}

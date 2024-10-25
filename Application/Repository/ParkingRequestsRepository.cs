using Database;
using Database.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class ParkingRequestsRepository
    {
        private readonly ApplicationContext _dbContext;

        public ParkingRequestsRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public async Task AddAsync(ParkingRequests parkingRequests)
        {
            await _dbContext.ParkingRequests.AddAsync(parkingRequests);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(ParkingRequests parkingRequests)
        {
            _dbContext.Entry(parkingRequests).State=EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(ParkingRequests parkingRequests)
        {
            _dbContext.Set<ParkingRequests>().Remove(parkingRequests);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<ParkingRequests>> GetAllAsync()
        {
            return await _dbContext.Set<ParkingRequests>().ToListAsync();
        }
        public async Task<ParkingRequests> GetByIdAsync(int id)
        {
            return await _dbContext.Set<ParkingRequests>().FindAsync(id);
        }

    }
}

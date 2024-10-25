using Database;
using Database.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class ParkingAuditLogsRepository
    {
        internal readonly ApplicationContext _dbContext;

        public ParkingAuditLogsRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddSync(ParkingAuditLogs parkingAuditLogs)
        {
            await _dbContext.ParkingAuditLogs.AddAsync(parkingAuditLogs);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(ParkingAuditLogs parkingAuditLogs)
        {
            _dbContext.Entry(parkingAuditLogs).State=EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(ParkingAuditLogs parkingAuditLogs)
        {
            _dbContext.Set<ParkingAuditLogs>().Remove(parkingAuditLogs);
            await _dbContext.SaveChangesAsync();   
        }
        public async Task<List<ParkingAuditLogs>> GetAllAsync()
        {
            return await _dbContext.Set<ParkingAuditLogs>().ToListAsync();
        }
        public async Task<ParkingAuditLogs> GetByIdAsync(int id)
        {
            return await _dbContext.Set<ParkingAuditLogs>().FindAsync(id);
        }







    }
}

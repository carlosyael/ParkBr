using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;
using Database.Model;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository
{
    public class ParkingSpotsRepository
    {
        private readonly ApplicationContext _dbContex;

        public ParkingSpotsRepository(ApplicationContext dbContex)
        {
            _dbContex = dbContex; 
        }
        public async Task AddAsync(ParkingSpots parkingSpots)
        {
            await _dbContex.ParkingSpots.AddAsync(parkingSpots);
            await _dbContex.SaveChangesAsync();
        }
        public async Task UpdateAsync(ParkingSpots parkingSpots)
        {
            _dbContex.Entry(parkingSpots).State =EntityState.Modified;
            await _dbContex.SaveChangesAsync();
        }
        public async Task DeleteAsync(ParkingSpots parkingSpots)
        {

            _dbContex.Set<ParkingSpots>().Remove(parkingSpots);
            await _dbContex.SaveChangesAsync();
        }
        public async Task<List<ParkingSpots>> GetAllAsync()
        {
            return await _dbContex.Set<ParkingSpots>().ToListAsync();
        }
        public async Task<ParkingSpots> GetByIdAsync(int id)
        {
            return await _dbContex.Set<ParkingSpots>().FindAsync(id);
        }





    }
}

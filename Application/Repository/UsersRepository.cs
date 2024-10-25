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
    public class UsersRepository
    {
        private readonly ApplicationContext _dbContext;

        public UsersRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Users users)
        {
            await _dbContext.Users.AddAsync(users);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Users users)
        {
            _dbContext.Entry(users).State=EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Users users)
        {
            _dbContext.Set<Users>().Remove(users);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<Users>> GetAllAsync()
        {
            return await _dbContext.Set<Users>().ToListAsync();
        }
        public async Task<Users> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Users>().FindAsync(id);
        }











    }
}

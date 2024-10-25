using Application.Repository;
using Application.ViewModels;
using Database;
using Database.Model;
using Application.SaveViewModel;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.AccessControl;

namespace Application.Service
{
    public class UsersService
    {
        private readonly UsersRepository _usersRepository;
        public UsersService(ApplicationContext dbContext) {
            _usersRepository = new(dbContext);
        }
        public async Task<List<UserViewModel>> GetAllViewModel()
        {
            var usersList = await _usersRepository.GetAllAsync();
            return usersList.Select(user=>new UserViewModel
            {
                FirstName= user.FirstName,
                LastName = user.LastName,
                Id = user.Id,
                Email= user.Email,
                ParkAssingned= user.ParkAssingned,
                Password= user.Password,
                CreateDate= user.CreateDate,
                Role_Id= user.Role_Id, 
                RoleName= user.RoleName,
            }).ToList();
        }
        public async Task<List<SaveUsersViewModel>> GetAllSaveViewModel()
        {
            var usersList = await _usersRepository.GetAllAsync();
            return usersList.Select(user => new SaveUsersViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Id = user.Id,
                Email = user.Email,
                ParkAssingned = user.ParkAssingned,
                Password = user.Password,
                CreateDate = user.CreateDate,
                Role_Id = user.Role_Id,
                RoleName = user.RoleName,
            }).ToList();
        }
        public async Task Add(SaveUsersViewModel svm)
        {
            Users user= new ();
            user.FirstName = svm.FirstName;
            user.LastName = svm.LastName;
            user.Email = svm.Email;
            user.RoleName = svm.RoleName;
            user.Role_Id = svm.Role_Id;
            user.CreateDate = svm.CreateDate;
            user.Password = svm.Password;
            user.ParkAssingned = svm.ParkAssingned;

            await _usersRepository.AddAsync(user); 
        }
        public async Task Update(SaveUsersViewModel svm)
        {
            Users user = new();
            user.FirstName = svm.FirstName;
            user.LastName = svm.LastName;
            user.Id = svm.Id;
            user.Email = svm.Email;
            user.RoleName = svm.RoleName;
            user.Role_Id = svm.Role_Id;
            user.CreateDate = svm.CreateDate;
            user.Password = svm.Password;
            user.ParkAssingned = svm.ParkAssingned;

            await _usersRepository.UpdateAsync(user);
        }
        public async Task<SaveUsersViewModel> GetByIdSVM(int id)
        {
            var user= await _usersRepository.GetByIdAsync(id);
            SaveUsersViewModel svm = new SaveUsersViewModel();
            svm.FirstName = user.FirstName;
            svm.LastName = user.LastName;
            svm.Id = user.Id;
            svm.Email = user.Email;
            svm.ParkAssingned = user.ParkAssingned;
            svm.Password = user.Password;
            svm.CreateDate = user.CreateDate;
            svm.Role_Id = user.Role_Id;
            svm.RoleName = user.RoleName;
            return svm;
        }

        public async Task Delete(int id)
        {
            var user = await _usersRepository.GetByIdAsync(id);
            await _usersRepository.DeleteAsync(user);
        }

    }
}

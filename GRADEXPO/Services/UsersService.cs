using System.Collections.Generic;
using System.Threading.Tasks;
using GRADEXPO.Models;
using GRADEXPO.Repository;
using System;

namespace GRADEXPO.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository usersRepository;

        public UsersService(IUsersRepository _usersRepository)
        {
            usersRepository = _usersRepository;
        }

        public async Task<Users.User> AddUserAsync(Users.User _usersModels)
        {
            return await usersRepository.AddUserAsync(_usersModels);
        }

        public async Task<IEnumerable<Users.User>> GetUsersAsync()
        {
            return await usersRepository.GetUsersAsync();
        }

        public async Task<Users.User> GetUserAsync(Int32 _userId)
        {
            return await usersRepository.GetUserAsync(_userId);
        }

        public async Task<Users.User> UpdateUserAsync(Users.User _userModel)
        {
            return await usersRepository.UpdateUserAsync(_userModel);
        }

        public async Task DeleteUserAsync(Int32 _userId)
        {
            await usersRepository.DeleteUserAsync(_userId);
        }

    }
}
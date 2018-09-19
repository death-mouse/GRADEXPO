using System.Collections.Generic;
using System.Threading.Tasks;
using GRADEXPO.Models;

namespace GRADEXPO.Services
{
    public interface IUsersService
    {
        Task<Users.User> GetUserAsync(int _userId);
        Task<Users.User> AddUserAsync(Users.User _userModel);
        Task<IEnumerable<Users.User>> GetUsersAsync();
        Task DeleteUserAsync(int _userId);
        Task<Users.User> UpdateUserAsync(Users.User _userModel);
    }
}
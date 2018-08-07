using System.Collections.Generic;
using System.Threading.Tasks;
using GRADEXPO.Models;

namespace GRADEXPO.Services
{
    public interface IUsersService
    {
        Task<Users> GetUserAsync(int _userId);
        Task<Users> AddUserAsync(Users _userModel);
        Task<IEnumerable<Users>> GetUsersAsync();
        Task DeleteUserAsync(int _userId);
        Task<Users> UpdateUserAsync(Users _userModel);
    }
}
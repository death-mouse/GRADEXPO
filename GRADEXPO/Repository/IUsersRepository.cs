using System.Collections.Generic;
using GRADEXPO.Models;
using System.Threading.Tasks;

namespace GRADEXPO.Repository
{
    public interface IUsersRepository
    {
        Task<Users> GetUserAsync(int userId);
        Task<Users> AddUserAsync(Users usersModel);
        Task<IEnumerable<Users>> GetUsersAsync();
        Task DeleteUserAsync(int id);
        Task<Users> UpdateUserAsync(Users userModel);
    }
}
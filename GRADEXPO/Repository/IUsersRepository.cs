using System.Collections.Generic;
using GRADEXPO.Models;
using System.Threading.Tasks;

namespace GRADEXPO.Repository
{
    public interface IUsersRepository
    {
        Task<Users.User> GetUserAsync(int userId);
        Task<Users.User> AddUserAsync(Users.User usersModel);
        Task<IEnumerable<Users.User>> GetUsersAsync();
        Task DeleteUserAsync(int id);
        Task<Users.User> UpdateUserAsync(Users.User userModel);
    }
}
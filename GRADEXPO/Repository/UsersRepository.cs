using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GRADEXPO.Models;
using System.Threading.Tasks;
using GRADEXPO.Repository;
using GRADEXPO.Context;
using System.Data.Entity;

namespace GRADEXPO.Repository
{
    public class UsersRepository : IUsersRepository
    {
        public UsersRepository() { }

        public async Task<Users> GetUserAsync(Int32 _userId)
        {
            Users result = null;

            using (var usersContext = new UsersContext())
            {
                result = await usersContext.users.FirstOrDefaultAsync(f=>f.userId == _userId);
            }

            return result;
        }

        public async Task<Users> AddUserAsync(Users _usersModel)
        {
            Users result = null;

            using (var usersContext = new UsersContext())
            {
                result = usersContext.users.Add(_usersModel);
                await usersContext.SaveChangesAsync();
            }

            return result;
        }

        public async Task<IEnumerable<Users>> GetUsersAsync()
        {
            var result = new List<Users>();

            using (var usersContext = new UsersContext())
            {
                result = await usersContext.users.ToListAsync();
            }

            return result;
        }

        public async Task DeleteUserAsync(Int32 id)
        {
            using (var usersContext = new UsersContext())
            {
                var student = await usersContext.users.FirstOrDefaultAsync(f => f.userId == id);

                usersContext.Entry(student).State = EntityState.Deleted;

                await usersContext.SaveChangesAsync();
            }
        }

        public async Task<Users> UpdateUserAsync(Users _usersModel)
        {
            using (var usersContext = new UsersContext())
            {
                usersContext.Entry(_usersModel).State = EntityState.Modified;

                await usersContext.SaveChangesAsync();
            }

            return _usersModel;
        }
    }
}
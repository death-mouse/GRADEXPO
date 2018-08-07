using System.Data.Entity;
using GRADEXPO.Models;

namespace GRADEXPO.Context
{
    public class UsersContext : DbContext
    {
        public UsersContext() : base("dbConnectionString")
        {
        }

        public DbSet<Users> users { get; set; }
    }
}
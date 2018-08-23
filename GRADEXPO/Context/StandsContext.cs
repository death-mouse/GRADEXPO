using System.Data.Entity;
using GRADEXPO.Models;

namespace GRADEXPO.Context
{
    public class StandsContext : DbContext
    {
        public StandsContext() : base("dbConnectionString")
        {
        }

        public DbSet<Stands> Stands { get; set; }
    }
}
using System.Data.Entity;
using GRADEXPO.Models;

namespace GRADEXPO.Context
{
    public class ExposContext : DbContext
    {
        public ExposContext() : base("dbConnectionString")
        {
        }

        public DbSet<Expos> Expos { get; set; }
    }
}
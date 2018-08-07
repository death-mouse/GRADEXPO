using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GRADEXPO.Models;
using System.Threading.Tasks;
using GRADEXPO.Repository;
using GRADEXPO.Context;
using System.Data.Entity;
using System;

namespace GRADEXPO.Repository
{
    public class ExposRepository : IExposRepository
    {
        public ExposRepository() { }

        public async Task<Expos> GetExpoAsync(Int32 _Id)
        {
            Expos result = null;

            using (var expoContext = new ExposContext())
            {
                result = await expoContext.Expos.FirstOrDefaultAsync(f => f.Id == _Id);
            }

            return result;
        }

        public async Task<Expos> AddExpoAsync(Expos _expos)
        {
            Expos result = null;

            using (var expoContext = new ExposContext())
            {
                result = expoContext.Expos.Add(_expos);
                await expoContext.SaveChangesAsync();
            }

            return result;
        }

        public async Task<IEnumerable<Expos>> GetExposAsync()
        {
            var result = new List<Expos>();

            using (var expoContext = new ExposContext())
            {
                result = await expoContext.Expos.ToListAsync();
            }

            return result;
        }

        public async Task DeleteExpoAsync(Int32 _id)
        {
            using (var expoContext = new ExposContext())
            {
                var student = await expoContext.Expos.FirstOrDefaultAsync(f => f.Id == _id);

                expoContext.Entry(student).State = EntityState.Deleted;

                await expoContext.SaveChangesAsync();
            }
        }

        public async Task<Expos> UpdateExpoAsync(Expos _expos)
        {
            using (var expoContext = new ExposContext())
            {
                expoContext.Entry(_expos).State = EntityState.Modified;

                await expoContext.SaveChangesAsync();
            }

            return _expos;
        }
    }
}
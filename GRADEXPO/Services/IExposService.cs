using System.Collections.Generic;
using System.Threading.Tasks;
using GRADEXPO.Models;

namespace GRADEXPO.Services
{
    public interface IExposService
    {
            Task<Expos> GetExpoAsync(int _Id);
            Task<Expos> AddExpoAsync(Expos _expo);
            Task<IEnumerable<Expos>> GetExposAsync();
            Task DeleteExpoAsync(int _id);
            Task<Expos> UpdateExpoAsync(Expos _expo);
    }
}
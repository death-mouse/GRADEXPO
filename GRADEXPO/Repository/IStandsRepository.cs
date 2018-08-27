using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GRADEXPO.Models;

namespace GRADEXPO.Repository
{
    public interface IStandsRepository
    {
        Task<Stands> GetStandAsync(int _expoId, int _standId);
        Task<IEnumerable<Stands>> GetStandsAsync(int _expoId);
        Task<Stands> AddStandAsync(Stands _stand);
        Task<IEnumerable<Stands>> GetStandsAsync();
        Task DeleteStendsAsync(int _expoId, int _standId);
        Task DeleteStendsAsync(int _standId);
        Task<Stands> UpdateStendAsync(Stands _stands);
        Task<StandFromJson.Value> getStands(int _expoId);
    }
}
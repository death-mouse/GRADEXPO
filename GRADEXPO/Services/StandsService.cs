using System.Collections.Generic;
using System.Threading.Tasks;
using GRADEXPO.Models;
using GRADEXPO.Repository;
using System;

namespace GRADEXPO.Services
{
    public class StandsService : IStandsService
    {
        private readonly IStandsService standsService;

        public StandsService(IStandsService _standsService)
        {
            standsService = _standsService;
        }
        public async Task<Stands> AddStandAsync(Stands _stand)
        {
            return await standsService.AddStandAsync(_stand);
        }

        public async Task DeleteStendsAsync(int _expoId, int _standId)
        {
            await standsService.DeleteStendsAsync(_expoId, _standId);
        }

        public async Task DeleteStendsAsync(int _standId)
        {
            await standsService.DeleteStendsAsync(_standId);
        }

        public async Task<Stands> GetStandAsync(int _expoId, int _standId)
        {
            return await standsService.GetStandAsync(_expoId, _standId);
        }

        public async Task<IEnumerable<Stands>> GetStandsAsync(int _expoId)
        {
            return await standsService.GetStandsAsync(_expoId);
        }

        public async Task<IEnumerable<Stands>> GetStandsAsync()
        {
            return await standsService.GetStandsAsync();
        }

        public async Task<Stands> UpdateStendAsync(Stands _stands)
        {
            return await standsService.UpdateStendAsync(_stands);
        }
    }
}
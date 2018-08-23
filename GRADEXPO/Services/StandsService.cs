using System.Collections.Generic;
using System.Threading.Tasks;
using GRADEXPO.Models;
using GRADEXPO.Repository;
using System;

namespace GRADEXPO.Services
{
    public class StandsService : IStandsService
    {
        private readonly IStandsRepository standsRepository;

        public StandsService(IStandsRepository _standsRepository)
        {
            standsRepository = _standsRepository;
        }
        public async Task<Stands> AddStandAsync(Stands _stand)
        {
            return await standsRepository.AddStandAsync(_stand);
        }

        public async Task DeleteStendsAsync(int _expoId, int _standId)
        {
            await standsRepository.DeleteStendsAsync(_expoId, _standId);
        }

        public async Task DeleteStendsAsync(int _standId)
        {
            await standsRepository.DeleteStendsAsync(_standId);
        }

        public async Task<Stands> GetStandAsync(int _expoId, int _standId)
        {
            return await standsRepository.GetStandAsync(_expoId, _standId);
        }

        public async Task<IEnumerable<Stands>> GetStandsAsync(int _expoId)
        {
            return await standsRepository.GetStandsAsync(_expoId);
        }

        public async Task<IEnumerable<Stands>> GetStandsAsync()
        {
            return await standsRepository.GetStandsAsync();
        }

        public async Task<Stands> UpdateStendAsync(Stands _stands)
        {
            return await standsRepository.UpdateStendAsync(_stands);
        }
    }
}
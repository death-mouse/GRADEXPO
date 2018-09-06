using GRADEXPO.Models;
using GRADEXPO.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace GRADEXPO.Services
{
    public class ExpoFilesService : IExpoFilesService
    {
        private readonly IExpoFilesRepository expoFilesRepository;

        public ExpoFilesService(IExpoFilesRepository _expoFilesRepository)
        {
            expoFilesRepository = _expoFilesRepository;
        }
        public async Task<ExpoFilesFromJson.ExpoFiles> AddExpoFilesFromJsonAsync(ExpoFilesFromJson.ExpoFiles _expoFilesFromJson, string _type = "fileExpo")
        {
            return await expoFilesRepository.AddExpoFilesFromJsonAsync(_expoFilesFromJson, _type);
        }

        public async Task DeleteExpoAsync(int _expoId, int _fileId)
        {
             await expoFilesRepository.DeleteExpoAsync(_expoId, _fileId);
        }

        public async Task<ExpoFilesFromJson.ExpoFiles> GetExpoFileJsonAsync(int _expoId, int _fileId)
        {
            return await expoFilesRepository.GetExpoFileJsonAsync(_expoId, _fileId);
        }

        public async Task<IEnumerable<ExpoFilesFromJson.ExpoFiles>> GetExpoFilesAsync(int _expoId)
        {
            return await expoFilesRepository.GetExpoFilesAsync(_expoId);
        }
    }
}
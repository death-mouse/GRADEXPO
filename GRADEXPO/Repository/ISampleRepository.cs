using GRADEXPO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace GRADEXPO.Repository
{
    public interface ISampleRepository
    {
        Task<SampleFromJson.Sample> GetSampleAsync(int _expoId, int _sampleId);

        Task<IEnumerable<SampleFromJson.Sample>> GetSamplesAsync();

        Task<IEnumerable<SampleFromJson.Sample>> GetSamplesByExpoIdAsync(int _expoId);
        Task<IEnumerable<SampleFromJson.Sample>> GetSamplesByVendorIdAsync(int _visitId);
        Task<IEnumerable<SampleFromJson.Sample>> GetSamplesByVisitIdAsync(int _visitId);

        Task<SampleFromJson.Sample> AddSampleAsync(SampleFromJson.Sample _sample);
        
        Task DeleteSamplesAsync(int _standId);

        Task<SampleFromJson.Sample> UpdateSamplesAsync(SampleFromJson.Sample _sample);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using GRADEXPO.Models;

namespace GRADEXPO.Repository
{
    public class SampleRepository : ISampleRepository
    {
        public async Task<SampleFromJson.Sample> AddSampleAsync(SampleFromJson.Sample _sample)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteSamplesAsync(int _standId)
        {
            throw new NotImplementedException();
        }

        public async Task<SampleFromJson.Sample> GetSampleAsync(int _expoId, int _sampleId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SampleFromJson.Sample>> GetSamplesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SampleFromJson.Sample>> GetSamplesByExpoIdAsync(int _expoId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SampleFromJson.Sample>> GetSamplesByVendorIdAsync(int _visitId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SampleFromJson.Sample>> GetSamplesByVisitIdAsync(int _visitId)
        {
            throw new NotImplementedException();
        }

        public async Task<SampleFromJson.Sample> UpdateSamplesAsync(SampleFromJson.Sample _sample)
        {
            throw new NotImplementedException();
        }
    }
}
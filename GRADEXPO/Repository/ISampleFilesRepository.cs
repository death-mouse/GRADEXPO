using GRADEXPO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace GRADEXPO.Repository
{
    public interface ISampleFilesRepository
    {
        Task<SampleFilesFromJson.SampleFiles> AddSampleFilesAsync(SampleFilesFromJson.SampleFiles _sampleFilesFromJson);

        Task<IEnumerable<SampleFilesFromJson.SampleFiles>> GetSampleFilesAsync(int _sampleId);
        Task<SampleFilesFromJson.SampleFiles> GetSampleFileJsonAsync(int _sampleId, int _fileId);
        Task DeleteSampleFileAsync(int _sampleId, int _fileId);
    }
}
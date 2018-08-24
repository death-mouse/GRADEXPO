using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using GRADEXPO.Models;
using GRADEXPO.Repository;

namespace GRADEXPO.Services
{
    public class FileService : IFileService
    {
        private readonly IFileRepository fileRepository;
        public FileService(IFileRepository _fileRepository)
        {
            fileRepository = _fileRepository;
        }
        public async Task<FileFromJson.File> AddFileFromJsonAsync(FileFromJson.File _file)
        {
            return await fileRepository.AddFileFromJsonAsync(_file);
        }

        public async Task DeleteExpoAsync(int _fileId)
        {
            await fileRepository.DeleteExpoAsync(_fileId);
        }

        public async Task<FileFromJson.File> GetFileJsonAsync(int _fileId)
        {
            return await fileRepository.GetFileJsonAsync(_fileId);
        }
    }
}
using GRADEXPO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace GRADEXPO.Services
{
    public interface IFileService
    {
        Task<FileFromJson.File> GetFileJsonAsync(int _fileId);
        Task DeleteExpoAsync(int _fileId);
        Task<FileFromJson.File> AddFileFromJsonAsync(FileFromJson.File _file);
    }
}
﻿using GRADEXPO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace GRADEXPO.Repository
{
    public interface IExpoFilesRepository
    {
        Task<ExpoFilesFromJson.ExpoFiles> AddExpoFilesFromJsonAsync(ExpoFilesFromJson.ExpoFiles _expoFilesFromJson, string _type);

        Task<IEnumerable<ExpoFilesFromJson.ExpoFiles>> GetExpoFilesAsync(int _expoId);
        Task<ExpoFilesFromJson.ExpoFiles> GetExpoFileJsonAsync(int _expoId, int _fileId);
        Task DeleteExpoAsync(int _expoId, int _fileId);

        
    }
}
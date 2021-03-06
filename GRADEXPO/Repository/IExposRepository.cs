﻿using System.Collections.Generic;
using System.Threading.Tasks;
using GRADEXPO.Models;

namespace GRADEXPO.Repository
{
    public interface IExposRepository
    {
        Task<Expos> GetExpoAsync(int _Id);
        Task<Expos> AddExpoAsync(Expos _expo);
        Task<IEnumerable<Expos>> GetExposAsync();
        Task DeleteExpoAsync(int _id);
        Task<Expos> UpdateExpoAsync(Expos _expo);
        Task<Expos> UpdateExpoFromJsonAsync(Expos _expo);
        Task<Expos> GetExpoFromJsonAsync(int _Id);
        Task<Expos> AddExpoFromJsonAsync(Expos _expo);
        Task<IEnumerable<Expos>> GetExposFromJsonAsync();
        Task DeleteExpoFromJsonAsync(int _id);
        

    }
}
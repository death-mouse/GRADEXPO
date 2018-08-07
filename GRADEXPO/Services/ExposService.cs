﻿using System.Collections.Generic;
using System.Threading.Tasks;
using GRADEXPO.Models;
using GRADEXPO.Repository;
using System;

namespace GRADEXPO.Services
{
    public class ExposService : IExposService
    {
        private readonly IExposRepository exposRepository;
        
        public ExposService(IExposRepository _exposRepository)
        {
            exposRepository = _exposRepository;
        }

        public async Task<Expos> AddExpoAsync(Expos _expo)
        {
            return await exposRepository.AddExpoAsync(_expo);
        }

        public async Task<IEnumerable<Expos>> GetExposAsync()
        {
            return await exposRepository.GetExposAsync();
        }

        public async Task<Expos> GetExpoAsync(Int32 _id)
        {
            return await exposRepository.GetExpoAsync(_id);
        }

        public async Task<Expos> UpdateExpoAsync(Expos _expos)
        {
            return await exposRepository.UpdateExpoAsync(_expos);
        }

        public async Task DeleteExpoAsync(Int32 _id)
        {
            await exposRepository.DeleteExpoAsync(_id);
        }
    }
}
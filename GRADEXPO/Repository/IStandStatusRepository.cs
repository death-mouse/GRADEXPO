using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using GRADEXPO.Models;

namespace GRADEXPO.Repository
{
    public interface IStandStatusRepository
    {
        Task<StandStatusFromJson.StandStatus> getStandStatusAsync(int _statusId);
        Task<IEnumerable<StandStatusFromJson.StandStatus>> getStandsStatusAsync();

        Task<StandStatusFromJson.StandStatus> addStandStatus(StandStatusFromJson.StandStatus _standStatus);
        Task<StandStatusFromJson.StandStatus> updateStandStatus(StandStatusFromJson.StandStatus _standStatus);

        Task deleteStandStatus(int _statusId);

    }
}
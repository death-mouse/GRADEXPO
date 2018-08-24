using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using GRADEXPO.Models;

namespace GRADEXPO.Repository
{
    public class StandStatusRepository : IStandStatusRepository
    {
        public Task<StandStatusFromJson.StandStatus> addStandStatus(StandStatusFromJson.StandStatus _standStatus)
        {
            throw new NotImplementedException();
        }

        public Task deleteStandStatus(int _statusId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<StandStatusFromJson.StandStatus>> getStandsStatusAsync()
        {
            throw new NotImplementedException();
        }

        public Task<StandStatusFromJson.StandStatus> getStandStatusAsync(int _statusId)
        {
            throw new NotImplementedException();
        }

        public Task<StandStatusFromJson.StandStatus> updateStandStatus(StandStatusFromJson.StandStatus _standStatus)
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GRADEXPO.Models;
using System.Threading.Tasks;
using GRADEXPO.Repository;
using GRADEXPO.Context;
using System.Data.Entity;
using Newtonsoft.Json;
using System.Net;

namespace GRADEXPO.Repository
{
    public class ExposRepository : IExposRepository
    {
        public ExposRepository() { }

        public async Task<Expos> GetExpoAsync(Int32 _Id)
        {
            Expos result = null;

            using (var expoContext = new ExposContext())
            {
                result = await expoContext.Expos.FirstOrDefaultAsync(f => f.expoId == _Id);
            }

            return result;
        }

        public async Task<Expos> AddExpoAsync(Expos _expos)
        {
            Expos result = null;

            using (var expoContext = new ExposContext())
            {
                result = expoContext.Expos.Add(_expos);
                await expoContext.SaveChangesAsync();
            }

            return result;
        }

        public async Task<IEnumerable<Expos>> GetExposAsync()
        {
            var result = new List<Expos>();

            using (var expoContext = new ExposContext())
            {
                result = await expoContext.Expos.ToListAsync();
            }

            return result;
        }

        public async Task DeleteExpoAsync(Int32 _id)
        {
            using (var expoContext = new ExposContext())
            {
                var student = await expoContext.Expos.FirstOrDefaultAsync(f => f.expoId == _id);

                expoContext.Entry(student).State = EntityState.Deleted;

                await expoContext.SaveChangesAsync();
            }
        }

        public async Task<Expos> UpdateExpoAsync(Expos _expos)
        {
            using (var expoContext = new ExposContext())
            {
                expoContext.Entry(_expos).State = EntityState.Modified;

                await expoContext.SaveChangesAsync();
            }

            return _expos;
        }

        public async Task<Expos> GetExpoFromJsonAsync(int _id)
        {
            string json = await GRADEXPO.HttpClient.Browser.GetAsync(string.Format("{0}{1}/{2}", Properties.Settings.Default.BaseUrlApi, Properties.Settings.Default.postfixGetExpo, _id));
            ExpoFromJson.RootObject result = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ExpoFromJson.RootObject>(json));
            if(result.Expos == null)
            {
                throw new WebException(string.Format("Не удалось найти выставку с Id = {0}. Убедитесь в корретности выбранной выставки", _id));
            }
            return result.Expos.Expo;
        }

        public async Task<ExposFromJson> AddExpoFromJsonAsync(ExposFromJson _expos)
        {
            ExposFromJson result = new ExposFromJson();


            return result;
        }

        public async Task<IEnumerable<Expos>> GetExposFromJsonAsync()
        {
            
            string json = await GRADEXPO.HttpClient.Browser.GetAsync(string.Format("{0}{1}", Properties.Settings.Default.BaseUrlApi, Properties.Settings.Default.postfixGetExpo));
            ExposFromJson.RootObject result = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ExposFromJson.RootObject>(json));
            
            return result.Expos.Expo;

        }

        public async Task DeleteExpoFromJsonAsync(Int32 _id)
        {
            using (var expoContext = new ExposContext())
            {
                var student = await expoContext.Expos.FirstOrDefaultAsync(f => f.expoId == _id);

                expoContext.Entry(student).State = EntityState.Deleted;

                await expoContext.SaveChangesAsync();
            }
        }

        public async Task<ExposFromJson> UpdateExpoFromJsonAsync(ExposFromJson _expos)
        {
            /*using (var expoContext = new ExposContext())
            {
                expoContext.Entry(_expos).State = EntityState.Modified;

                await expoContext.SaveChangesAsync();
            }*/

            return _expos;
        }
    }
}
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
            Expos expos = null;
            string json = await HttpClient.Browser.GetAsync(string.Format("{0}{1}({2})", Properties.Settings.Default.BaseUrlApi, Properties.Settings.Default.postfixGetExpo, _id));
            Expos rootObject = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<Expos>(json));
            expos = rootObject;
            return expos;
        }

        public async Task<Expos> AddExpoFromJsonAsync(Expos _expos)
        {
            Expos result = new Expos();
            string json = JsonConvert.SerializeObject(_expos, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Ignore });
            string res = await HttpClient.Browser.ByMethodAsync(string.Format("{0}{1}", Properties.Settings.Default.BaseUrlApi, Properties.Settings.Default.postfixGetExpo), json, "POST");

            return result;
        }

        public async Task<IEnumerable<Expos>> GetExposFromJsonAsync()
        {
            
            List<Expos> expos = null;
            string json = await HttpClient.Browser.GetAsync(string.Format("{0}{1}", Properties.Settings.Default.BaseUrlApi, Properties.Settings.Default.postfixGetExpo));
            ExposFromJson.Values rootObject = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ExposFromJson.Values>(json));
            expos = rootObject.value;
            return expos;

        }

        public async Task DeleteExpoFromJsonAsync(Int32 _id)
        {
            string res = await HttpClient.Browser.DeleteAsync(string.Format("{0}{1}({2})", Properties.Settings.Default.BaseUrlApi, Properties.Settings.Default.postfixGetExpo, _id));
        }

        public async Task<GRADEXPO.Models.Expos> UpdateExpoFromJsonAsync(GRADEXPO.Models.Expos _expos)
        {
            
            string json = JsonConvert.SerializeObject(_expos, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Ignore });
            string res = await HttpClient.Browser.ByMethodAsync(string.Format("{0}{1}({2})", Properties.Settings.Default.BaseUrlApi, Properties.Settings.Default.postfixGetExpo, _expos.expoId), json, "PUT");

            return _expos;
        }
    }
}
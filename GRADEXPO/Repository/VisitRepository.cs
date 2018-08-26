using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using GRADEXPO.Models;
using Newtonsoft.Json;

namespace GRADEXPO.Repository
{
    public class VisitRepository : IVisitRepository
    {
        public async Task<VisitFromJson.Visit> addVisit(VisitFromJson.Visit _visit)
        {
            VisitFromJson.Visit visit = null;
            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "Json":
                    string json = JsonConvert.SerializeObject(_visit, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore });
                    string res = await HttpClient.Browser.ByMethodAsync(string.Format("{0}{1}", Properties.Settings.Default.BaseUrlApi, Properties.Settings.Default.postfixGetVisit), json, "POST");
                    visit = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<VisitFromJson.Visit>(res));
                    break;
                default:
                    throw new System.Exception(string.Format("Приложение не умеет работать с типом данных {0}. Если вам нужно работать с такими типом данным, обратитесь к разработчику", Properties.Settings.Default.GetDataFrom));
            }

            return visit;
        }

        public async Task deleteVisit(int _visitId)
        {
            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "Json":
                    await GRADEXPO.HttpClient.Browser.DeleteAsync(string.Format("{0}{1}({2})", Properties.Settings.Default.BaseUrlApi,
                                                                                                             Properties.Settings.Default.postfixGetVisit,
                                                                                                             _visitId));
                    break;
                default:
                    throw new System.Exception(string.Format("Приложение не умеет работать с типом данных {0}. Если вам нужно работать с такими типом данным, обратитесь к разработчику", Properties.Settings.Default.GetDataFrom));
            }
        }

        public async Task<VisitFromJson.Visit> getVisit(int _visitId)
        {
            VisitFromJson.Visit visit = null;
            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "Json":
                    string res = await HttpClient.Browser.GetAsync(string.Format("{0}{1}({2})", Properties.Settings.Default.BaseUrlApi, Properties.Settings.Default.postfixGetVisit, _visitId));
                    visit = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<VisitFromJson.Visit>(res));
                    break;
                default:
                    throw new System.Exception(string.Format("Приложение не умеет работать с типом данных {0}. Если вам нужно работать с такими типом данным, обратитесь к разработчику", Properties.Settings.Default.GetDataFrom));
            }

            return visit;
        }

        public Task<VisitFromJson.Visit> getVisit(int _visitId, int _expoId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<VisitFromJson.Visit>> getVisitsByExpo(int _expoId)
        {
            List<VisitFromJson.Visit> visit = null;
            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "Json":
                    string res = await HttpClient.Browser.GetAsync(string.Format("{0}{1}({2})/{3}", Properties.Settings.Default.BaseUrlApi, Properties.Settings.Default.postfixGetExpo, _expoId, Properties.Settings.Default.postfixGetVisit));
                    VisitFromJson.Values value = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<VisitFromJson.Values>(res, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore }));
                    visit = value.value;
                    break;
                default:
                    throw new System.Exception(string.Format("Приложение не умеет работать с типом данных {0}. Если вам нужно работать с такими типом данным, обратитесь к разработчику", Properties.Settings.Default.GetDataFrom));
            }

            return visit;
        }

        public Task<VisitFromJson.Visit> updateVisit(VisitFromJson.Visit _visit)
        {
            throw new NotImplementedException();
        }
    }
}
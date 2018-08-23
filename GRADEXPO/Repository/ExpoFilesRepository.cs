using GRADEXPO.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using models = GRADEXPO.Models;

namespace GRADEXPO.Repository
{
    public class ExpoFilesRepository : IExpoFilesRepository
    {
        public ExpoFilesRepository() { }

        public async Task<models.ExpoFilesFromJson.ExpoFiles> AddExpoFilesFromJsonAsync(models.ExpoFilesFromJson.ExpoFiles _expoFilesFromJson)
        {
            ExpoFilesFromJson.ExpoFiles expoFiles = null;
            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "Json":
                    string json = JsonConvert.SerializeObject(_expoFilesFromJson, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Ignore });
                    string res = await HttpClient.Browser.ByMethodAsync(string.Format("{0}{1}", Properties.Settings.Default.BaseUrlApi, Properties.Settings.Default.postfixGetFileExpo), json, "POST");
                    expoFiles = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ExpoFilesFromJson.ExpoFiles>(res));
                    break;
                default:
                    throw new System.Exception(string.Format("Приложение не умеет работать с типом данных {0}. Если вам нужно работать с такими типом данным, обратитесь к разработчику", Properties.Settings.Default.GetDataFrom));
            }

            return expoFiles;
        }


        public Task DeleteExpoAsync(int _expoId, int _fileId)
        {
            throw new NotImplementedException();
        }

        public async Task<ExpoFilesFromJson.ExpoFiles> GetExpoFileJsonAsync(int _expoId, int _fileId)
        {
            ExpoFilesFromJson.ExpoFiles expoFiles = null;
            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "Json":
                    string json = await GRADEXPO.HttpClient.Browser.GetAsync(string.Format("{0}{1}(fileId = {2}, expoId = {3})", Properties.Settings.Default.BaseUrlApi,
                                                                                                             Properties.Settings.Default.postfixGetProject,
                                                                                                             _fileId,
                                                                                                             _expoId));
                    ExpoFilesFromJson.ExpoFiles expoFilesResult = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ExpoFilesFromJson.ExpoFiles>(json));
                    expoFiles = expoFilesResult;
                    break;
                default:
                    throw new System.Exception(string.Format("Приложение не умеет работать с типом данных {0}. Если вам нужно работать с такими типом данным, обратитесь к разработчику", Properties.Settings.Default.GetDataFrom));
            }

            return expoFiles;
        }

        public async Task<IEnumerable<models.ExpoFilesFromJson.ExpoFiles>> GetExpoFilesAsync(int _expoId)
        {
            List<ExpoFilesFromJson.ExpoFiles> result = null;
            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "Json":
                    string json = await GRADEXPO.HttpClient.Browser.GetAsync(string.Format("{0}{1}({2})/{3})", Properties.Settings.Default.BaseUrlApi,
                                                                                                             Properties.Settings.Default.postfixGetExpo,
                                                                                                             _expoId,
                                                                                                             Properties.Settings.Default.postfixGetFileExpo));
                    ExpoFilesFromJson.Values expoFilesResult = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ExpoFilesFromJson.Values>(json));
                    result = expoFilesResult.value;
                    break;
                default:
                    throw new System.Exception(string.Format("Приложение не умеет работать с типом данных {0}. Если вам нужно работать с такими типом данным, обратитесь к разработчику", Properties.Settings.Default.GetDataFrom));
            }

            return result;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using GRADEXPO.Models;
using Newtonsoft.Json;

namespace GRADEXPO.Repository
{
    public class SampleFilesRepository : ISampleFilesRepository
    {
        public async Task<SampleFilesFromJson.SampleFiles> AddSampleFilesAsync(SampleFilesFromJson.SampleFiles _sampleFilesFromJson)
        {
            SampleFilesFromJson.SampleFiles sampleFiles = null;
            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "Json":
                    string json = JsonConvert.SerializeObject(_sampleFilesFromJson, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore });
                    string res = await HttpClient.Browser.ByMethodAsync(string.Format("{0}{1}", Properties.Settings.Default.BaseUrlApi, Properties.Settings.Default.postfixGetSampleFiles), json, "POST");
                    sampleFiles = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<SampleFilesFromJson.SampleFiles>(res));
                    break;
                default:
                    throw new System.Exception(string.Format("Приложение не умеет работать с типом данных {0}. Если вам нужно работать с такими типом данным, обратитесь к разработчику", Properties.Settings.Default.GetDataFrom));
            }

            return sampleFiles;
        }

        public Task DeleteSampleFileAsync(int _sampleId, int _fileId)
        {
            throw new NotImplementedException();
        }

        public async Task<SampleFilesFromJson.SampleFiles> GetSampleFileJsonAsync(int _sampleId, int _fileId)
        {
            SampleFilesFromJson.SampleFiles expoFiles = null;
            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "Json":
                    string json = await GRADEXPO.HttpClient.Browser.GetAsync(string.Format("{0}{1}(fileId = {2}, sampleId = {3})", Properties.Settings.Default.BaseUrlApi,
                                                                                                             Properties.Settings.Default.postfixGetSampleFiles,
                                                                                                             _fileId,
                                                                                                             _sampleId));
                    expoFiles = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<SampleFilesFromJson.SampleFiles>(json));
                    break;
                default:
                    throw new System.Exception(string.Format("Приложение не умеет работать с типом данных {0}. Если вам нужно работать с такими типом данным, обратитесь к разработчику", Properties.Settings.Default.GetDataFrom));
            }

            return expoFiles;
        }

        public async Task<IEnumerable<SampleFilesFromJson.SampleFiles>> GetSampleFilesAsync(int _sampleId)
        {
            List<SampleFilesFromJson.SampleFiles> result = null;
            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "Json":
                    string json = await GRADEXPO.HttpClient.Browser.GetAsync(string.Format("{0}{1}({2})/{3})", Properties.Settings.Default.BaseUrlApi,
                                                                                                             Properties.Settings.Default.postfixgetSample,
                                                                                                             _sampleId,
                                                                                                             Properties.Settings.Default.postfixGetSampleFiles));
                    SampleFilesFromJson.Values producteFilesResult = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<SampleFilesFromJson.Values>(json));
                    result = producteFilesResult.value;
                    break;
                default:
                    throw new System.Exception(string.Format("Приложение не умеет работать с типом данных {0}. Если вам нужно работать с такими типом данным, обратитесь к разработчику", Properties.Settings.Default.GetDataFrom));
            }

            return result;
        }
    }
}
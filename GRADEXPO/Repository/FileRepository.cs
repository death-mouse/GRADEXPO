using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using GRADEXPO.Models;
using Newtonsoft.Json;

namespace GRADEXPO.Repository
{
    public class FileRepository : IFileRepository
    {
        public async Task<FileFromJson.File> AddFileFromJsonAsync(FileFromJson.File _file)
        {
            FileFromJson.File newFile = null;
            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "Json":
                    string json = JsonConvert.SerializeObject(_file, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore });
                    string res = await HttpClient.Browser.ByMethodAsync(string.Format("{0}{1}", Properties.Settings.Default.BaseUrlApi, Properties.Settings.Default.postfixGetFile), json, "POST");
                    newFile = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<FileFromJson.File>(res));
                    break;
                default:
                    throw new System.Exception(string.Format("Приложение не умеет работать с типом данных {0}. Если вам нужно работать с такими типом данным, обратитесь к разработчику", Properties.Settings.Default.GetDataFrom));
            }

            return newFile;
        }

        public async Task DeleteExpoAsync(int _fileId)
        {
            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "Json":
                    await GRADEXPO.HttpClient.Browser.DeleteAsync(string.Format("{0}{1}({2})", Properties.Settings.Default.BaseUrlApi,
                                                                                                             Properties.Settings.Default.postfixGetFile,
                                                                                                             _fileId));
                    break;
                default:
                    throw new System.Exception(string.Format("Приложение не умеет работать с типом данных {0}. Если вам нужно работать с такими типом данным, обратитесь к разработчику", Properties.Settings.Default.GetDataFrom));
            }


        }

        public async Task<FileFromJson.File> GetFileJsonAsync(int _fileId)
        {
            FileFromJson.File file = null;
            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "Json":
                    string json = await GRADEXPO.HttpClient.Browser.GetAsync(string.Format("{0}{1}({2})", Properties.Settings.Default.BaseUrlApi,
                                                                                                             Properties.Settings.Default.postfixGetFile,
                                                                                                             _fileId));
                    file = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<FileFromJson.File>(json));
                    break;
                    break;
                default:
                    throw new System.Exception(string.Format("Приложение не умеет работать с типом данных {0}. Если вам нужно работать с такими типом данным, обратитесь к разработчику", Properties.Settings.Default.GetDataFrom));
            }

            return file;
        }
    }
}
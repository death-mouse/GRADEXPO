using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using GRADEXPO.Models;
namespace GRADEXPO.HttpClient
{
    public class Browser
    {
        public static async Task<string> GetAsync(string uri)
        {
            string ret = "";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            httpWebRequest.ContentType = "Application/json;odata.metadata=none";
            httpWebRequest.Accept = "Application/json;odata.metadata=none";
            httpWebRequest.UserAgent = "DeAmouSE User Agent";
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)await httpWebRequest.GetResponseAsync())
                using (Stream stream = response.GetResponseStream())
                    try
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            ret = await reader.ReadToEndAsync();

                        }
                    }
                    catch (Exception e)
                    {
                        throw new Exception(e.Message);
                    }

                if (ret.Contains("error"))
                {
                    ErrorModel.RootObject rootObject = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ErrorModel.RootObject>(ret, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore }));
                    throw new Exception(rootObject.error);
                }
                if(ret == "")
                {
                    throw new Exception(string.Format("При запросе методом GET по ссылке {0}. Получили пустой ответ", uri));
                }
            }
            catch (WebException wex)
            {
                var pageContent = new StreamReader(wex.Response.GetResponseStream())
                                      .ReadToEnd();
                ErrorModel.RootObject rootObject = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ErrorModel.RootObject>(pageContent, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore }));
                if(rootObject != null && rootObject.error != null)
                    throw new Exception(rootObject.error);
                else
                    throw new Exception(wex.Message);
            }
            return ret;
        }

        public static async Task<string> DeleteAsync(string uri)
        {
            string ret = "";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            httpWebRequest.ContentType = "Application/json;odata.metadata=none";
            httpWebRequest.Accept = "Application/json;odata.metadata=none";
            httpWebRequest.UserAgent = "DeAmouSE User Agent";
            httpWebRequest.Method = "DELETE";
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)await httpWebRequest.GetResponseAsync())
                using (Stream stream = response.GetResponseStream())
                    try
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            ret = await reader.ReadToEndAsync();

                        }
                    }
                    catch (Exception e)
                    {
                        return e.Message;
                    }
                if (ret.Contains("error"))
                {
                    ErrorModel.RootObject rootObject = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ErrorModel.RootObject>(ret, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore }));
                    throw new Exception(rootObject.error);
                }
            }
            catch (WebException wex)
            {
                var pageContent = new StreamReader(wex.Response.GetResponseStream())
                                      .ReadToEnd();
                ErrorModel.RootObject rootObject = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ErrorModel.RootObject>(pageContent, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore }));
                if (rootObject.error != null)
                    throw new Exception(rootObject.error);
                else
                    throw new Exception(wex.Message);
            }
            if (ret == "")
            {
                throw new Exception(string.Format("При запросе методом DELETE по ссылке {0}. Получили пустой ответ", uri));
            }
            return ret;
        }
        public static async Task<string> ByMethodAsync (string uri, string json, string method)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpWebRequest.ContentType = "Application/json;odata.metadata=none";
            httpWebRequest.Accept = "Application/json;odata.metadata=none";
            httpWebRequest.Method = method;
            httpWebRequest.UserAgent = "DeAmouSE User Agent";
            string result = "";
            try
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = await streamReader.ReadToEndAsync();
                }
                if (result.Contains("error"))
                {
                    ErrorModel.RootObject rootObject = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ErrorModel.RootObject>(result, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore }));
                    throw new Exception(rootObject.error);
                }
            }
            catch (WebException wex)
            {
                var pageContent = new StreamReader(wex.Response.GetResponseStream())
                                      .ReadToEnd();
                ErrorModel.RootObject rootObject = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ErrorModel.RootObject>(pageContent, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore }));
                if (rootObject.error != null)
                    throw new Exception(rootObject.error);
                else
                    throw new Exception(wex.Message);
            }
            if (result == "")
            {
                throw new Exception(string.Format("При запросе методом {0} по ссылке {1}. Получили пустой ответ", method, uri));
            }
            return result;
        }


    }
}
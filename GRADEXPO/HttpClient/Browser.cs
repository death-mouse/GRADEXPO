using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
namespace GRADEXPO.HttpClient
{
    public class Browser
    {
        public static async Task<string> GetAsync(string uri)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            httpWebRequest.ContentType = "Application/json;odata.metadata=none";
            httpWebRequest.Accept = "Application/json;odata.metadata=none";
            httpWebRequest.UserAgent = "DeAmouSE User Agent";
            using (HttpWebResponse response = (HttpWebResponse)await httpWebRequest.GetResponseAsync())
            using (Stream stream = response.GetResponseStream())
                try
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        return await reader.ReadToEndAsync();
                    }
                }
                catch (Exception e)
                {
                    return e.Message;
                }

            
        }

        public static async Task<string> DeleteAsync(string uri)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            httpWebRequest.ContentType = "Application/json;odata.metadata=none";
            httpWebRequest.Accept = "Application/json;odata.metadata=none";
            httpWebRequest.UserAgent = "DeAmouSE User Agent";
            httpWebRequest.Method = "DELETE";
            using (HttpWebResponse response = (HttpWebResponse)await httpWebRequest.GetResponseAsync())
            using (Stream stream = response.GetResponseStream())
                try
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        return await reader.ReadToEndAsync();
                    }
                }
                catch (Exception e)
                {
                    return e.Message;
                }
        }
        public static async Task<string> ByMethodAsync (string uri, string json, string method)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpWebRequest.ContentType = "Application/json;odata.metadata=none";
            httpWebRequest.Accept = "Application/json;odata.metadata=none";
            httpWebRequest.Method = method;
            httpWebRequest.UserAgent = "DeAmouSE User Agent";
            string result = "";
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

            return result;
        }


    }
}
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
namespace GRADEXPO.HttpClient
{
    public class Browser
    {
        public static async Task<string> GetAsync(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            request.ContentType = "Application/json;odata.metadata=none";
            request.Accept = "Application/json;odata.metadata=none";
            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            using (Stream stream = response.GetResponseStream())
                try
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        return await reader.ReadToEndAsync();
                    }
                }catch (Exception e)
                {
                    return "";
                }
        }
    }
}
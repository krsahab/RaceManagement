using System;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace Utility
{
    public class APIHelper
    {
        private static readonly HttpClient httpClient;
        static APIHelper()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIBaseAddress"]);
        }
        public static async Task<HttpResponseMessage> GetDataAsync(string URL)
        {
            return await httpClient.GetAsync(URL);
        }
        public static async Task<HttpResponseMessage> PostDataAsync(string url, HttpContent content)
        {
            return await httpClient.PostAsync(url, content);
        }
        public static async Task<HttpResponseMessage> PutDataAsync(string url, HttpContent content)
        {
            return await httpClient.PutAsync(url, content);
        }
        public static async Task<HttpResponseMessage> DeleteDataAsync(string url)
        {
            return await httpClient.DeleteAsync(url);
        }
    }
}

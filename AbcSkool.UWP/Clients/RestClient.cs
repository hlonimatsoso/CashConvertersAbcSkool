using AbcSkool.Interfaces;
using AbcSkool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AbcSkool.UWP.Clients
{
    public class RestClient : IRestClient
    {
        HttpClient _client;
        public RestClient()
        {
            _client = Factory.HttpClient;
        }
        public async Task<T> Get<T>(string url)
        {
            T result = default(T);

            try
            {
                using (this._client)
                {
                    var responseTask = _client.GetAsync(url);
                    responseTask.Wait();
                    var x = responseTask.Result;

                    if (x.IsSuccessStatusCode)
                        result = await x.Content.ReadAsAsync<T>();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return result;
        }
    }
}

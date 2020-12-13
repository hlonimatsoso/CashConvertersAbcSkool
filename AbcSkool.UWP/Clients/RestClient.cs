using AbcSkool.Interfaces;
using AbcSkool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace AbcSkool.UWP.Clients
{
    public class RestClient : IRestClient
    {
        HttpClient _client;
        public RestClient()
        {
            //_client = Factory.HttpClient;
            _client = new HttpClient() { BaseAddress = new Uri(Config.ApiBaseUrl) };

        }

        public async Task DeleteAsync(string url, int id)
        {
            try
            {
                var responseTask = _client.DeleteAsync($"{url}/{id}");
                responseTask.Wait();
                var result = responseTask.Result;

                //}
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<T> Get<T>(string url)
        {
            T result = default(T);

            try
            {
                //using (this._client)
                //{
                var responseTask = _client.GetAsync(url);
                responseTask.Wait();
                var x = responseTask.Result;

                if (x.IsSuccessStatusCode)
                    result = await x.Content.ReadAsAsync<T>();
                //}
            }
            catch (Exception ex)
            {
                string title = $"OH SNAP! API Error!";

                string msg = $"Askies, the system is offline. \n Exception : {ex.Message}. \n Inner Exception : {ex.InnerException?.Message}.";
                var dialog = new MessageDialog(msg, title);
                dialog.ShowAsync();
                // Log error

            }

            return result;
        }

        public async Task Post<T>(string url, T data)
        {
            T result = default(T);

            try
            {
                //using (this._client)
                //{
                var responseTask = _client.PostAsJsonAsync(url, data);
                responseTask.Wait();
                var x = responseTask.Result;

                if (x.IsSuccessStatusCode)
                    result = await x.Content.ReadAsAsync<T>();
                //}
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task PutAsync<T>(string url, T data)
        {
            T result = default(T);

            try
            {
                //using (this._client)
                //{
                var responseTask = _client.PutAsJsonAsync(url, data);
                responseTask.Wait();
                var x = responseTask.Result;

                if (x.IsSuccessStatusCode)
                    result = await x.Content.ReadAsAsync<T>();
                //}
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}

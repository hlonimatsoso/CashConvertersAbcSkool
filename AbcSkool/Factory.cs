using AbcSkool.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace AbcSkool
{
    public static class Factory
    {
        private static HttpClient _httpClient;
        public static HttpClient HttpClient
        {
            get
            {
                if (_httpClient == null)
                    _httpClient = new HttpClient() { BaseAddress = new Uri(Config.ApiBaseUrl) };

                return _httpClient;
            }
        }


    }
}

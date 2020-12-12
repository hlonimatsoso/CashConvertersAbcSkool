using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AbcSkool.Interfaces
{
    public interface IRestClient 
    {
        Task<T> Get<T>(string url);
    }
}

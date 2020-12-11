using System;
using System.Collections.Generic;
using System.Text;

namespace AbcSkool.Interfaces
{
    public interface IGenericService<T> : IGenericRepository<T> where T : class
    {

    }
}

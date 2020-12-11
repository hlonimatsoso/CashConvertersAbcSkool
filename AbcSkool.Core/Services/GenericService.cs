using AbcSkool.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcSkool.Core.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        IGenericRepository<T> _repo;

        public GenericService(IGenericRepository<T> repo)
        {
            this._repo = repo;
        }

        public void Delete(object id)
        {
            this._repo.Delete(id);
        }

        public IEnumerable<T> GetAll()
        {
            return this._repo.GetAll();
        }

        public T GetById(object id)
        {
            return this._repo.GetById(id);
        }

        public void Insert(T obj)
        {
            this._repo.Insert(obj);
        }

        public void Save()
        {
            this._repo.Save();
        }

        public void Update(T obj)
        {
            this._repo.Update(obj);
        }
    }
}

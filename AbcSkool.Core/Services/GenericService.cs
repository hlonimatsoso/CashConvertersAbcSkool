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

        public async Task DeleteAsync(object id)
        {
            await this._repo.DeleteAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await this._repo.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await this._repo.GetByIdAsync(id);
        }

        public async Task AddAsync(T obj)
        {
           await this._repo.AddAsync(obj);
        }

        public async Task SaveAsync()
        {
           await this._repo.SaveAsync();
        }

        public async Task UpdateAsync(T obj)
        {
           await this._repo.UpdateAsync(obj);
        }
    }
}

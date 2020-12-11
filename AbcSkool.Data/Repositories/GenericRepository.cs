using AbcSkool.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcSkool.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private AbcSkoolDbContext _context = null;
        private DbSet<T> table = null;


        public GenericRepository(AbcSkoolDbContext context)
        {
            this._context = context;
            table = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await table.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"DB Error => Failed to get all {typeof(T).Name}s.", ex);
            }
        }
        public async Task<T> GetByIdAsync(object id)
        {
            try
            {
                return await table.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"DB Error => Failed to get a {typeof(T).Name} with the ID of {id}.", ex);
            }
        }
        public async Task AddAsync(T obj)
        {
            try
            {
                await table.AddAsync(obj);
            }
            catch (Exception ex)
            {
                throw new Exception($"DB Error => Failed to add a {typeof(T).Name}. Details: {obj.ToString()}.", ex);
            }
        }
        public async Task UpdateAsync(T obj)
        {
            try
            {
                await Task.Run(() =>
                {
                    table.Attach(obj);
                    _context.Entry(obj).State = EntityState.Modified;
                });
            }
            catch (Exception ex)
            {
                throw new Exception($"DB Error => Failed to update {typeof(T).Name}. Details: {obj.ToString()}.", ex);
            }

        }
        public async Task DeleteAsync(object id)
        {
            try
            {
                await Task.Run(async () =>
                {
                    T existing = await table.FindAsync(id);

                    if (existing == null)
                        throw new Exception($"No {typeof(T)} with an ID of {id} was found in the datbase.");

                    table.Remove(existing);

                });
            }
            catch (Exception ex)
            {
                throw new Exception($"DB Error => Failed to delete a {typeof(T).Name} with the ID {id}.", ex);
            }

        }
        public async Task SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"DB Error => Failed to save any changes to any table.", ex);
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteBanSua_L.Reponsive.Base
{
    public class BaseRepo<T> : IBaseRepo<T>
        where T : class
    {
        public WebsiteBanSua_LContext _context;
        public string idRepo {  get; set; }
        public BaseRepo(WebsiteBanSua_LContext context)
        {
            idRepo = "";
            _context = context;
        }

        public async Task CreateRepo(T item)
        {
            await _context.Set<T>().AddAsync(item); 
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetAsync(string id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if(entity != null) {
                idRepo = id;
            }
            return entity;
        }
        public async Task DeleteRepo(string  id)
        {
            T entity = await _context.Set<T>().FindAsync(id);
            if(entity == null)
            {
                throw new ArgumentException($"Entity with{id} not found");
            }
            _context.Set<T>().Remove(entity);

            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }


        public async Task UpdateRepo(T item)
        {
            if (item == null)
            {
                throw new ArgumentException(nameof(item));
            }
            _context.Set<T>().Update(item);
            await _context.SaveChangesAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteBanSua_L.Reponsive.Base
{
    public interface IBaseRepo<T> 
        where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(string id);
        Task<T> CreateRepo(T item);
        Task<T> DeleteRepo(string id);
        Task<T> UpdateRepo(T item);
    }
}

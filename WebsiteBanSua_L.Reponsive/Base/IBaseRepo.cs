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
        string idRepo { get; set; }
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(string id);
        Task CreateRepo(T item);
        Task DeleteRepo(string id);
        Task UpdateRepo(T item);
    }
}

using Model.Data;
using Model.Entities;
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
        Task<T> GetAsync(int id);
        Task CreateRepo(T item);
        Task DeleteRepo(int id);
        Task UpdateRepo(T item);
       
    }
}

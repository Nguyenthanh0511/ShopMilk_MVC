using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteBanSua_L.Reponsive.Base;

namespace Service.Base
{
    public interface IBaseService<T,TRepo>
        where T : class 
        where TRepo : IBaseRepo<T>
    {
        bool Flag {  get; set; }
        string Error {  get; set; }
        Task Get(string id);
        Task<List<T>> GetAll();
        Task Create(T item);
        Task Update(T item);
        Task Delete(string id);
        
    }
}

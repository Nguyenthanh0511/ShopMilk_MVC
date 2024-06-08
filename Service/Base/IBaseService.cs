using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteBanSua_L.Reponsive.Base;

namespace Service.Base
{
    public interface IBaseService<T>  where T : class
    {
        bool Flag {  get; set; }
        string Error {  get; set; }
        Task<T> Get(string id);
        Task<List<T>> GetAll();
        Task Create(T item);
        Task Update(T item);
        Task Delete(string id);
    }
}

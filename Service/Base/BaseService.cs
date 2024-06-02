using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteBanSua_L.Reponsive.Base;

namespace Service.Base
{
    public class BaseService<T, TRepo> : IBaseService<T, TRepo>
        where T : class, new() where TRepo : BaseRepo<T>
    {
        public bool Flag { get; set; }
        public string Error { get; set; }

        private readonly TRepo ThisRepo;
        public BaseService(TRepo thisRepo)
        {
            this.Flag = true;
            this.Error = "";
            ThisRepo = thisRepo;
        }
        public async Task Create(T item)
        {
            try
            {
                await ThisRepo.CreateRepo(item);
            }
            catch(Exception ex)
            {
                Flag = false;
                Error = ex.Message;
            }
        }

        public async Task Delete(string id)
        {

            try
            {
                await ThisRepo.DeleteRepo(id);
            }catch(Exception ex)
            {
                Flag = false;
                Error = ex.Message;
            }

        }

        public async Task Get(string id)
        {
            try
            {
                await ThisRepo.GetAsync(id);
            }catch(Exception ex)
            {
                Flag = false;
                Error = ex.Message;
            }
        }

        public async Task<List<T>> GetAll()
        {
            try
            {
                return await ThisRepo.GetAllAsync();
            }
            catch(Exception ex)
            {
                Flag = false;
                Error = ex.Message;
                return new List<T>();
            }
        }

        public async Task Update(T item)
        {
            try
            {
                await ThisRepo.UpdateRepo(item);
            }catch(Exception e)
            {
                Flag = false;
                Error = e.Message;
            }
        }
    }
}

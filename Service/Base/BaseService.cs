using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebsiteBanSua_L.Reponsive.Base;

namespace Service.Base
{
    public class BaseService<T, TRepo> : IBaseService<T>
        where T : class, new()
        where TRepo : IBaseRepo<T>
    {
        public string Id { get; set; }
        public bool Flag { get; set; }
        public string Error { get; set; }

        private readonly TRepo _repo;

        public BaseService(TRepo repo)
        {
            Id = string.Empty;
            Flag = true;
            Error = string.Empty;
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public async Task Create(T item)
        {
            try
            {
                if (item == null)
                {
                    throw new ArgumentNullException(nameof(item));
                }

                await _repo.CreateRepo(item);
            }
            catch (Exception ex)
            {
                Flag = false;
                Error = ex.Message;
            }
        }

        public async Task Delete(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    throw new ArgumentException("Id cannot be null or empty", nameof(id));
                }

                await _repo.DeleteRepo(id);
            }
            catch (Exception ex)
            {
                Flag = false;
                Error = ex.Message;
            }
        }

        public async Task<T> Get(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    throw new ArgumentException("Id cannot be null or empty", nameof(id));
                }

                var entity = await _repo.GetAsync(id);
                return entity;
            }
            catch (Exception ex)
            {
                Flag = false;
                Error = ex.Message;
                return null;
            }
        }

        public async Task<List<T>> GetAll()
        {
            try
            {
                return await _repo.GetAllAsync();
            }
            catch (Exception ex)
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
                if (item == null)
                {
                    throw new ArgumentNullException(nameof(item));
                }

                await _repo.UpdateRepo(item);
            }
            catch (Exception ex)
            {
                Flag = false;
                Error = ex.Message;
            }
        }
    }
}







//--------------------
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using WebsiteBanSua_L.Reponsive.Base;

//namespace Service.Base
//{
//    public class BaseService<T, TRepo> : IBaseService<T>
//        where T : class, new() where TRepo : IBaseRepo<T>
//    {
//        public string id {  get; set; }
//        public bool Flag { get; set; }
//        public string Error { get; set; }

//        private readonly TRepo ThisRepo;
//        public BaseService(TRepo thisRepo)
//        {
//            this.id = "";
//            this.Flag = true;
//            this.Error = "";
//            ThisRepo = thisRepo;
//        }
//        public async Task Create(T item)
//        {
//            try
//            {
//                await ThisRepo.CreateRepo(item);
//            }
//            catch(Exception ex)
//            {
//                Flag = false;
//                Error = ex.Message;
//            }
//        }

//        public async Task Delete(string id)
//        {

//            try
//            {
//                await ThisRepo.DeleteRepo(id);
//            }catch(Exception ex)
//            {
//                Flag = false;
//                Error = ex.Message;
//            }

//        }

//        public async Task<T> Get(string id)
//        {
//            try
//            {
//                var entity = await ThisRepo.GetAsync(id);
//                return entity;
//            }catch(Exception ex)
//            {
//                Flag = false;
//                Error = ex.Message;
//                return null;
//            }
//        }

//        public async Task<List<T>> GetAll()
//        {
//            try
//            {
//                return await ThisRepo.GetAllAsync();
//            }
//            catch(Exception ex)
//            {
//                Flag = false;
//                Error = ex.Message;
//                return new List<T>();
//            }
//        }

//        public async Task Update(T item)
//        {
//            try
//            {
//                await ThisRepo.UpdateRepo(item);
//            }catch(Exception e)
//            {
//                Flag = false;
//                Error = e.Message;
//            }
//        }
//    }
//}

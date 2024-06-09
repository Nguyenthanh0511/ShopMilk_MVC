using Model.Entities;
using Service.Base;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteBanSua_L.Reponsive.Base;

namespace Service.Service
{
    public class UserService : BaseService<Users, IBaseRepo<Users>>,IUserService
    {
        public UserService(IBaseRepo<Users> repo) : base(repo)
        {
        }

        public async Task<Users> SignIn(string username, string password)
        {
            if(username == null || password == null)
            {
                throw new ArgumentNullException("username");
            }
            else
            {
                var entityList = await _repo.GetAllAsync();
                Users user = (from u in entityList
                                where u.UserName == username && u.password == password
                                select u).FirstOrDefault();
               if(user == null)
                {
                    return null;
                }
                return user;
            }
        }
        //Login

    }
}

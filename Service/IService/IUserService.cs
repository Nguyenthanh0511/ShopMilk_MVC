using Model.Entities;
using Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IUserService : IBaseService<Users>
    {
        Task<Users> SignIn(string username, string password);

    }
}

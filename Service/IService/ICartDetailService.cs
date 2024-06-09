using Model.Entities;
using Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface ICartDetailService : IBaseService<CartDetail>
    {
        Task<List<CartDetail>> getAllCart();
        Task AddCart(int userid, int productid, int quantity);
        Task removeCart(int idProduct);
      
    }
}
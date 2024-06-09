using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteBanSua_L.Reponsive.Base;

namespace WebsiteBanSua_L.Reponsive
{
    public interface ICartDetailRepo:IBaseRepo<CartDetail>
    {
        Task<CartDetail> getIdProductUser(int userid, int productid);
    }
}

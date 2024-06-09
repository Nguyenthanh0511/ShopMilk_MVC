using Microsoft.EntityFrameworkCore;
using Model.Data;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteBanSua_L.Reponsive.Base;

namespace WebsiteBanSua_L.Reponsive
{
    public class CartDetailRepo : BaseRepo<CartDetail>, ICartDetailRepo
    {
        public CartDetailRepo(WebsiteBanSua_LContext context) : base(context)
        {
        }
        public async Task<CartDetail> getIdProductUser(int userid, int productid)
        {
            try
            {
                return await _context.cartsDetail.FirstOrDefaultAsync(cd => cd.UserId == userid && cd.ProdId == productid);
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                // Log the exception or return null
                throw new Exception("Error retrieving cart detail.", ex);
            }
        }
    }
}

using Model.Data;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteBanSua_L.Reponsive.Base;
using WebsiteBanSua_L.Reponsive.IReponsive;

namespace WebsiteBanSua_L.Reponsive.Reponsive
{
    public class ProductRepo : BaseRepo<Product>,IProductRepo
    {
        public ProductRepo(WebsiteBanSua_LContext _context): base(_context) { }
    }
}

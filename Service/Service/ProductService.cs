using Model.Entities;
using Service.Base;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteBanSua_L.Reponsive.Reponsive;

namespace Service.Service
{
    public class ProductService : BaseService<Product, ProductRepo>, IProductService
    {
        public ProductService(ProductRepo thisRepo) : base(thisRepo)
        {
        }
    }
}

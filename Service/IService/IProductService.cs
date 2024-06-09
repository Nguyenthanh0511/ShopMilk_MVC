using Model.Entities;
using Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IProductService : IBaseService<Product>
    {
        Task<Product> GetIdByCategory(int categoryId);
    }
}

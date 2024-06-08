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
    public class CategoryService : BaseService<Category,IBaseRepo<Category>>,ICategoryService
    {
        public CategoryService(IBaseRepo<Category> thisRepo) : base(thisRepo)
        {
        }
    }
}

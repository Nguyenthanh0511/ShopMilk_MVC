using Model.Data;
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
    public class ProductService : BaseService<Product, IBaseRepo<Product>>, IProductService
    {
        private readonly WebsiteBanSua_LContext _context;
        private readonly IBaseRepo<Category> _repoCategory;
        public ProductService(IBaseRepo<Product> thisRepo, WebsiteBanSua_LContext context, IBaseRepo<Category> repo) : base(thisRepo)
        {
            _context = context;
            _repoCategory = repo;
        }

        public async Task<Product> GetById(int id)
        {
            var entity = await _context.products.FindAsync(id);
            return entity;
        }

        public async Task<List<Product>> GetIdByCategory(int categoryId)
        {
            var productList = await _repo.GetAllAsync();
            var categoryList = await _repoCategory.GetAllAsync();
            var entity = (from p in productList
                          join cate in categoryList
                          on p.CateId equals cate.Id
                          where cate.Id == categoryId
                          select p);
            return entity.ToList();
        }
    }
}
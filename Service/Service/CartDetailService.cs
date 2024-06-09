using Microsoft.EntityFrameworkCore;
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
    public class CartDetailService : BaseService<CartDetail, IBaseRepo<CartDetail>>, ICartDetailService
    {
        private readonly IUserService _userService;
        private readonly IProductService _productService;
        private readonly WebsiteBanSua_LContext _context;
        public CartDetailService(WebsiteBanSua_LContext context, IBaseRepo<CartDetail> repo, IUserService userService, IProductService productService) : base(repo)
        {
            _context = context;
            _userService = userService;
            _productService = productService;
        }

        public async Task addCart(int userid, int productid, int quantity)
        {
            //var idUser = await _context.users.Where(u => u.Id == userid).Select(x => x.Id).FirstOrDefaultAsync();
            //var idProduct = await _context.products.Where(u => u.Id == productid).Select(x => x.Id).FirstOrDefaultAsync();
            var ListCart = await _repo.GetAllAsync();
            //find cart at the moment
            var cartDetail =   ListCart
                              .FirstOrDefault( u => u.UserId == userid && u.ProdId == productid);
            var product = await _productService.Get(productid);
            if(product == null)
            {
                Flag = false;
                return;
            }
            if (cartDetail == null)
            {
                CartDetail newCartDetail = new CartDetail()
                {
                    UserId = userid,
                    ProdId = productid,
                    Quantity = quantity,
                    DateBuy = DateTime.Now,
                };
                _repo.CreateRepo(newCartDetail);
            }
            else
            {
                cartDetail.Quantity += quantity;
                cartDetail.Total += product.Price;
                cartDetail.DateBuy = DateTime.Now;
                _repo.UpdateRepo(cartDetail);
            }
            await _context.SaveChangesAsync();
        }

        public Task<List<CartDetail>> getAllCart()
        {
            throw new NotImplementedException();
        }

        public Task removeCart(int idProduct)
        {
            throw new NotImplementedException();
        }
    }
}

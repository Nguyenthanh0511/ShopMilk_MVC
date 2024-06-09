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
using WebsiteBanSua_L.Reponsive;
using WebsiteBanSua_L.Reponsive.Base;

namespace Service.Service
{
    public class CartDetailService : BaseService<CartDetail, ICartDetailRepo>, ICartDetailService
    {
        private readonly IUserService _userService;
        private readonly IProductService _productService;
        private readonly WebsiteBanSua_LContext _context;
        public CartDetailService(WebsiteBanSua_LContext context, ICartDetailRepo repo) : base(repo)
        {
            _context = context;
        }
       
        public async Task AddCart(int userId, int productId, int quantity)
        {
            try
            {
                var cartDetail = await _repo.getIdProductUser(userId, productId);

                if (cartDetail == null)
                {
                    var newCartDetail = new CartDetail
                    {
                        UserId = userId,
                        ProdId = productId,
                        Quantity = quantity,
                        DateBuy = DateTime.Now
                    };

                    await _repo.CreateRepo(newCartDetail);
                }
                else
                {
                    var product = await _context.products.FirstOrDefaultAsync(p => p.Id == productId);
                    if (product != null)
                    {
                        cartDetail.Quantity += quantity;
                        cartDetail.Total += product.Price * quantity;
                        cartDetail.DateBuy = DateTime.Now;

                        await _repo.UpdateRepo(cartDetail);
                    }
                    else
                    {
                        throw new InvalidOperationException($"Product with ID {productId} not found.");
                    }
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                // Log the exception or return an appropriate response
                throw new Exception("Error adding item to cart.", ex);
            }
        }

       

        //public async Task addCart(int userid, int productid, int quantity)
        //{
        //    //var idUser = await _context.users.Where(u => u.Id == userid).Select(x => x.Id).FirstOrDefaultAsync();
        //    //var idProduct = await _context.products.Where(u => u.Id == productid).Select(x => x.Id).FirstOrDefaultAsync();
        //    var ListCart = await _repo.GetAllAsync();
        //    //find cart at the moment
        //    var cartDetail =   ListCart
        //                      .FirstOrDefault( u => u.UserId == userid && u.ProdId == productid);
        //    if (cartDetail == null)
        //    {
        //        CartDetail newCartDetail = new CartDetail()
        //        {
        //            UserId = userid,
        //            ProdId = productid,
        //            Quantity = quantity,
        //            DateBuy = DateTime.Now,
        //        };
        //        _repo.CreateRepo(newCartDetail);
        //    }
        //    else
        //    {
        //        var product = _context.products.Where(p=>p.Id==productid).FirstOrDefault();
        //        cartDetail.Quantity += quantity;
        //        cartDetail.Total += product.Price;
        //        cartDetail.DateBuy = DateTime.Now;
        //        _repo.UpdateRepo(cartDetail);
        //    }
        //    await _context.SaveChangesAsync();
        //}

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

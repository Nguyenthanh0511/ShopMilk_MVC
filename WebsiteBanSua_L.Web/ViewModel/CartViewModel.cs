using Model.Entities;

namespace WebsiteBanSua_L.Web.ViewModel
{
    public class CartViewModel
    {
        public int UserId { get; set; }
        public int ProdId {  get; set; }
        public int quantity {  get; set; }
        public List<Product> listProduct { get; set; }
        public Users user { get; set; } 
    }
}

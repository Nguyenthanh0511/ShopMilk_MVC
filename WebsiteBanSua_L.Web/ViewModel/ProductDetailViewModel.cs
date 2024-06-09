using Model.Entities;

namespace WebsiteBanSua_L.Web.ViewModel
{
    public class ProductDetailViewModel
    {
        public Product product { get; set; }
        public List<Product> listProduct { get; set; }
        public List<Image> listImage { get; set; }
    }
}

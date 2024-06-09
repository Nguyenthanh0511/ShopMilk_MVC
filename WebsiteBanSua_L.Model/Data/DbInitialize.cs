using Model.Data;
using Model.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Net.WebRequestMethods;

namespace Model.Data
{
    public class DataInitializer
    {
        private readonly IServiceProvider _serviceProvider;

        public DataInitializer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Seed()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<WebsiteBanSua_LContext>();

                // Check if there are any existing products
                if(!context.categorys.Any())
                {
                    var categories = new List<Category>()
                    {
                        new Category
                        {
                            Name="Sữa tươi"
                        },
                        new Category// Đây, lúc ở program vẫn chạy được và savechanges lên sql bình thường.
                        {
                            Name = "Sữa chua tự nhiên"
                        }
                    };
                    context.categorys.AddRange(categories);
                    context.SaveChanges();
                }
                if (!context.products.Any())
                {
                    var products = new List<Product>
                    {
                        new Product {Name = "LỐC SỮA TƯƠI DINH DƯỠNG DÀNH CHO NGƯỜI LỚN TUỔI TH TRUE MILK GOLD VỊ TỰ NHIÊN 180 ML X 4 HỘP", 
                            ImageUrl="https://www.thtruemart.vn/media/catalog/product/cache/207e23213cf636ccdef205098cf3c8a3/t/h/th-true-milk-gold-2024_1_.jpg", 
                            Description="Sữa Tươi Tiệt Trùng Vị Tự Nhiên TH true MILK GOLD là sản phẩm sữa tươi với công thức dinh dưỡng cho người lớn đầu tiên tại Việt Nam nhằm hỗ trợ nâng cao sức khoẻ tổng thể. Sản phẩm được bổ sung dưỡng chất cao cấp đem lại 06 lợi ích:\r\nTim mạch: sterol esters thực vật\r\nCải thiện giấc ngủ: chất GABA\r\nXương khớp: Canxi, Vitamin D3, K2 và Collagen\r\nTiêu hoá: chất xơ Inulin\r\nĐề kháng: Kẽm, Beta-glucan\r\nSức khoẻ tổng thể: bộ Vitamin và Khoáng chất", 
                            Price = 72.10, CateId = 1 },
                        new Product {Name = "THÙNG SỮA LÚA MẠCH TH TRUE CHOCOMALT MISTORI 180 ML X 48 HỘP",
                            ImageUrl = "https://www.thtruemart.vn/media/catalog/product/cache/207e23213cf636ccdef205098cf3c8a3/t/h/thung-sua-lua-mach-th-true-chocomalt-mistori-180ml-1_1.jpg",
                            Description = "Sản phẩm là sự kết hợp giữa sữa tươi sạch, chiết xuất lúa mạch và cacao tự nhiên cùng các thành phần/dưỡng chất hoàn toàn từ thiên nhiên. Cung cấp năng lượng giúp trẻ sẵn sàng cho mọi hoạt động thể chất hàng ngày. Hương vị thơm ngon vượt trội, chứa bộ vi chất giúp phát triển não bộ và chiều cao",
                            Price = 393.000,
                            CateId = 1}
                        // Add other products here
                    };

                    context.products.AddRange(products);
                    context.SaveChanges();
                }

                //Gallery
                if (!context.images.Any())
                {
                    var Image = new List<Image>()
                    {
                        new Image
                        {
                            thumbnail = "https://www.thtruemart.vn/media/catalog/product/cache/3380650127d143eec657262365bd2ea0/h/o/hop-sua-lua-mach-th-true-chocomalt-mistori-180ml-1_2.jpg",ProdId = 2
                        },
                        new Image
                        {
                            thumbnail = "https://www.thtruemart.vn/media/catalog/product/cache/207e23213cf636ccdef205098cf3c8a3/t/h/thung-sua-lua-mach-th-true-chocomalt-mistori-180ml-1_1.jpg", ProdId = 2
                        },
                        new Image
                        {
                            thumbnail = "https://www.thtruemart.vn/media/catalog/product/cache/3380650127d143eec657262365bd2ea0/h/o/hop-sua-lua-mach-th-true-chocomalt-mistori-180ml-3_2.jpg", ProdId = 2
                        },
                        new Image
                        {
                            thumbnail = "https://www.thtruemart.vn/media/catalog/product/cache/3380650127d143eec657262365bd2ea0/s/c/scums_viet_quat_800x800.png",ProdId = 3
                        },
                        new Image
                        {
                            thumbnail = "https://www.thtruemart.vn/media/catalog/product/cache/3380650127d143eec657262365bd2ea0/h/o/hop-sua-chua-uong-topkid-chuoi-lua-mach_1.jpg"
                            ,ProdId = 3
                        }
                    };
                    context.images.AddRange(Image);
                    context.SaveChanges();
                }
            }
        }
    }
}

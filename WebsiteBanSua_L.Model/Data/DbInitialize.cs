using Model.Data;
using Model.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

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
                if (!context.products.Any())
                {
                    var products = new List<Product>
                    {
                        new Product {Id="P1", Name = "Product 1", ImageUrl="https://www.thtruemart.vn/media/catalog/product/cache/207e23213cf636ccdef205098cf3c8a3/t/h/th-true-milk-gold-2024_1_.jpg", Description="Description for Product 1", Price = 10.50, CateId = "a11" },
                        // Add other products here
                    };

                    context.products.AddRange(products);
                    context.SaveChanges();
                }
            }
        }
    }
}

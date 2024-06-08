using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the product name.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "The name must be between 3 and 100 characters.")]
        public string Name { get; set; }
        [StringLength(500, ErrorMessage = "The description cannot exceed 500 characters.")]
        public string ImageUrl { get; set; }
        [StringLength(500, ErrorMessage = "The description cannot exceed 500 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter the product price.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "The price must be greater than 0.")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Please select a category.")]
        public int CateId { get; set; }

        public Category Category { get; set; }

        public List<Image> Images { get; set; }

        public List<CartDetail> CartDetails { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public Product()
        {
            CartDetails = new List<CartDetail>();
            OrderDetails = new List<OrderDetail>();
            Images = new List<Image>();
        }
    }
}

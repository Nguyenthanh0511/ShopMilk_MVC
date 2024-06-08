using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class CartDetail
    {
        [Key]
        public int UserId { get; set; }
        [Key]
        public int ProdId {  get; set; }
        [Display(Name ="Quantity")]
        [Required(ErrorMessage = "Don't empty")]
        [Range(0,1000)]
        public int Quantity { get; set; }
        [Display(Name = "Total")]
        [Required(ErrorMessage ="Don't empty")]
        [Range(1,double.MaxValue)]
        public double Total {  get; set; }
        [Display(Name = "DateBuy")]
        [Required(ErrorMessage = "Don't empty")]
        [DataType(DataType.Date)]
        public DateTime DateBuy { get; set; }
        public Product Product { get; set; }
        public Users User { get; set; }
        
    }
}

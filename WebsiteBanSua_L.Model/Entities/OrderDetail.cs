using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class OrderDetail
    {
        [Key]
        public string OrId {  get; set; }
        [Key]
        public string ProdId {  get; set; }
        [Display(Name ="Quantity")]
        [Required(ErrorMessage = "Don't empty")]
        [StringLength(100)]
        [Range(0.01,int.MaxValue,ErrorMessage ="False")]
        public int quantity {  get; set; }
        [Display(Name = "Total")]
        [Required(ErrorMessage = "Don't empty")]
        [Range(1,double.MaxValue,ErrorMessage = "False")]
        public double Total {  get; set; }
        [Display(Name ="OrId")]
        [Required(ErrorMessage = "Don't empty")]
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}

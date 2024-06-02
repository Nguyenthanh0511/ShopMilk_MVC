using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Order
    {
        [Key]
        public string Id { get; set; }
        [Display(Name ="Date")]
        [Required(ErrorMessage ="Don't empty")]
        [DataType(DataType.DateTime)]
        public DateTime Date {  get; set; }
        [Display(Name ="UserId")]
        public string UserId { get; set; }
        public Users User { get; set; }
        public ICollection<OrderDetail> OrderDetails {  get; set; }
        public Order() {
            OrderDetails = new List<OrderDetail>();
        }
    }
}

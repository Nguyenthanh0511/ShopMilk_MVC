using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Don't empty")]
        [StringLength(100)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Don't empty")]
        [StringLength(5)]
        public string role {  get; set; }
        public ICollection<CartDetail> CartDetails { get; set; }
        public ICollection<Order> Orders { get; set; }
        public Users() { 
            CartDetails = new List<CartDetail>();
            Orders = new List<Order>();
        }
    }
}

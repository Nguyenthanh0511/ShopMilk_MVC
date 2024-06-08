using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Don't empty")]
        public string thumbnail {  get; set; }
        public string ProdId {  get; set; }
        public Product Product { get; set; }
    }
}

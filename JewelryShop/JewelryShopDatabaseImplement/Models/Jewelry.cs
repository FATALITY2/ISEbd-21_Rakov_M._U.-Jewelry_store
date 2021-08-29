using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JewelryShopDatabaseImplement.Models
{
    public class Jewelry
    {
        public int Id { get; set; }

        [ForeignKey("JewelryId")]
        public virtual List<JewelryComponent> JewelryComponent { get; set; }

        [ForeignKey("JewelryId")]
        public virtual List<Order> Order { get; set; }

        [Required]
        public string JewelryName { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}

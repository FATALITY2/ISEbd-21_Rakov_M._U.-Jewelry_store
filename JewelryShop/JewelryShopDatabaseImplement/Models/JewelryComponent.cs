using System.ComponentModel.DataAnnotations;

namespace JewelryShopDatabaseImplement.Models
{
    public class JewelryComponent
    {
        public int Id { get; set; }

        public int JewelryId { get; set; }

        public int ComponentId { get; set; }

        [Required]
        public int Count { get; set; }

        public virtual Component Component { get; set; }

        public virtual Jewelry Jewelry { get; set; }
    }
}

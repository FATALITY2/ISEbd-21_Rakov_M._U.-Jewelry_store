using System.Collections.Generic;

namespace JewelryShopFileImplements.Models
{
    public class Jewelry
    {
        public int Id { get; set; }

        public string JewelryName { get; set; }

        public decimal Price { get; set; }

        public Dictionary<int, int> JewelryComponents { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel;

namespace JewelryShopBusinessLogic.ViewModels
{
    public class JewelryViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название изделия")]
        public string JewelryName { get; set; }

        [DisplayName("Цена")]
        public decimal Price { get; set; }

        public Dictionary<int, (string, int)> JewelryComponents { get; set; }
    }
}

using System.Collections.Generic;

namespace JewelryShopBusinessLogic.BindingModels
{
    public class JewelryBindingModel
    {
        public int? Id { get; set; }

        public string JewelryName { get; set; }

        public decimal Price { get; set; }

        public Dictionary<int, (string, int)> JewelryComponents { get; set; }
    }
}

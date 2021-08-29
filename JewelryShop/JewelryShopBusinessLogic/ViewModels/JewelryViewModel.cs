using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace JewelryShopBusinessLogic.ViewModels
{
    [DataContract]
    public class JewelryViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [DisplayName("Название изделия")]
        public string JewelryName { get; set; }

        [DataMember]
        [DisplayName("Цена")]
        public decimal Price { get; set; }

        [DataMember]
        public Dictionary<int, (string, int)> JewelryComponents { get; set; }
    }
}
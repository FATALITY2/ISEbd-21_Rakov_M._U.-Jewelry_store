using System;
using System.Collections.Generic;
using System.Text;
using JewelryShopBusinessLogic.ViewModels;

namespace JewelryShopBusinessLogic.HelperModels
{
    class WordInfo
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public List<JewelryViewModel> Jewelrys { get; set; }
    }
}

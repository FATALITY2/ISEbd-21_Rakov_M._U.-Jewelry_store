using System;
using System.Collections.Generic;
using System.Text;
using JewelryShopBusinessLogic.Enums;

namespace JewelryShopBusinessLogic.ViewModels
{
    public class ReportOrdersViewModel
    {
        public DateTime DateCreate { get; set; }

        public string JewelryName { get; set; }

        public int Count { get; set; }

        public decimal Sum { get; set; }

        public string Status { get; set; }
    }
}

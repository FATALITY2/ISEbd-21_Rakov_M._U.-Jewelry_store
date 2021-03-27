﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JewelryShopListImplements.Models
{
    public class Warehouse
    {
        public int Id { get; set; }

        public string WarehouseName { get; set; }

        public string Responsible { get; set; }

        public DateTime DateCreate { get; set; }

        public Dictionary<int, int> WarehouseComponents { get; set; } // Id, count)
    }
}
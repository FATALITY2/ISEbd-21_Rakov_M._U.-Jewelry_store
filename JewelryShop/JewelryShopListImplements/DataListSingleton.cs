using JewelryShopListImplements.Models;
using System.Collections.Generic;

namespace JewelryShopListImplements
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;

        public List<Component> Components { get; set; }

        public List<Order> Orders { get; set; }

        public List<Jewelry> Jewelrys { get; set; }
        public List<Warehouse> Warehouses { get; set; }

        private DataListSingleton()
        {
            Components = new List<Component>();
            Orders = new List<Order>();
            Jewelrys = new List<Jewelry>();
            Warehouses = new List<Warehouse>();
        }

        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}

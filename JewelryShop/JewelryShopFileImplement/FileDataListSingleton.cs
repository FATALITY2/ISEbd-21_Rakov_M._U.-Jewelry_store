using JewelryShopBusinessLogic.Enums;
using JewelryShopFileImplements.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace JewelryShopFileImplement
{
    public class FileDataListSingleton
    {
        private static FileDataListSingleton instance;

        private readonly string ComponentFileName = "Component.xml";

        private readonly string OrderFileName = "Order.xml";

        private readonly string JewelryFileName = "Jewelry.xml";

        public List<Component> Components { get; set; }

        public List<Order> Orders { get; set; }

        public List<Jewelry> Jewelrys { get; set; }

        private FileDataListSingleton()
        {
            Components = LoadComponents();
            Orders = LoadOrders();
            Jewelrys = LoadJewelrys();
        }

        public static FileDataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new FileDataListSingleton();
            }
            return instance;
        }

        ~FileDataListSingleton()
        {
            SaveComponents();
            SaveOrders();
            SaveJewelrys();
        }

        private List<Component> LoadComponents()
        {
            var list = new List<Component>();
            if (File.Exists(ComponentFileName))
            {
                XDocument xDocument = XDocument.Load(ComponentFileName);
                var xElements = xDocument.Root.Elements("Component").ToList();

                foreach (var elem in xElements)
                {
                    list.Add(new Component
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ComponentName = elem.Element("ComponentName").Value
                    });
                }
            }
            return list;
        }

        private List<Order> LoadOrders()
        {
            var list = new List<Order>();
            if (File.Exists(OrderFileName))
            {
                XDocument xDocument = XDocument.Load(OrderFileName);
                var xElements = xDocument.Root.Elements("Order").ToList();

                foreach (var elem in xElements)
                {
                    OrderStatus status = 0;
                    switch (elem.Element("Status").Value)
                    {
                        case "Принят":
                            status = OrderStatus.Принят;
                            break;
                        case "Выполняется":
                            status = OrderStatus.Выполняется;
                            break;
                        case "Готов":
                            status = OrderStatus.Готов;
                            break;
                        case "Оплачен":
                            status = OrderStatus.Оплачен;
                            break;
                    }

                    DateTime date = Convert.ToDateTime(null);
                    if (elem.Element("DateImplement").Value != "")
                    {
                        date = Convert.ToDateTime(elem.Element("DateImplement").Value);
                    }
                    list.Add(new Order
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        JewelryId = Convert.ToInt32(elem.Element("JewelryId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value),
                        Sum = Convert.ToDecimal(elem.Element("Sum").Value),
                        Status = status,
                        DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value),
                        DateImplement = date
                    });
                }
            }
            return list;
        }

        private List<Jewelry> LoadJewelrys()
        {
            var list = new List<Jewelry>();
            if (File.Exists(JewelryFileName))
            {
                XDocument xDocument = XDocument.Load(JewelryFileName);
                var xElements = xDocument.Root.Elements("Jewelry").ToList();
                foreach (var elem in xElements)
                {
                    var jewelComp = new Dictionary<int, int>();
                    foreach (var component in
                    elem.Element("JewelryComponents").Elements("JewelryComponent").ToList())
                    {
                        jewelComp.Add(Convert.ToInt32(component.Element("Key").Value),
                        Convert.ToInt32(component.Element("Value").Value));
                    }
                    list.Add(new Jewelry
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        JewelryName = elem.Element("JewelryName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value),
                        JewelryComponents = jewelComp
                    });
                }
            }
            return list;
        }

        private void SaveComponents()
        {
            if (Components != null)
            {
                var xElement = new XElement("Components");
                foreach (var component in Components)
                {
                    xElement.Add(new XElement("Component",
                    new XAttribute("Id", component.Id),
                    new XElement("ComponentName", component.ComponentName)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ComponentFileName);
            }
        }

        private void SaveOrders()
        {
            if (Orders != null)
            {
                var xElement = new XElement("Orders");
                foreach (var order in Orders)
                {
                    xElement.Add(new XElement("Order",
                    new XAttribute("Id", order.Id),
                    new XElement("JewelryId", order.JewelryId),
                    new XElement("Count", order.Count),
                    new XElement("Sum", order.Sum),
                    new XElement("Status", order.Status),
                    new XElement("DateCreate", order.DateCreate),
                    new XElement("DateImplement", order.DateImplement)));

                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }
        }

        private void SaveJewelrys()
        {
            if (Jewelrys != null)
            {
                var xElement = new XElement("Jewelrys");
                foreach (var jewelry in Jewelrys)
                {
                    var compElement = new XElement("JewelryComponents");
                    foreach (var component in jewelry.JewelryComponents)
                    {
                        compElement.Add(new XElement("JewelryComponent",
                        new XElement("Key", component.Key),
                        new XElement("Value", component.Value)));
                    }
                    xElement.Add(new XElement("Jewelry",
                    new XAttribute("Id", jewelry.Id),
                    new XElement("JewelryName", jewelry.JewelryName),
                    new XElement("Price", jewelry.Price),
                    compElement));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(JewelryFileName);
            }
        }
    }
}



using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JewelryShopBusinessLogic.BindingModels;
using JewelryShopBusinessLogic.HelperModels;
using JewelryShopBusinessLogic.Interfaces;
using JewelryShopBusinessLogic.ViewModels;
using JewelryShopBusinessLogic.Enums;

namespace JewelryShopBusinessLogic.BuisnessLogics
{
    public class ReportLogic
    {
        private readonly IComponentStorage _componentStorage;

        private readonly IJewelryStorage _jewelryStorage;

        private readonly IOrderStorage _orderStorage;

        public ReportLogic(IJewelryStorage jewelryStorage, IComponentStorage
        componentStorage, IOrderStorage orderStorage)
        {
            _jewelryStorage = jewelryStorage;
            _componentStorage = componentStorage;
            _orderStorage = orderStorage;
        }
        /// <summary>
        /// Получение списка компонент с указанием, в каких изделиях используются
        /// </summary>
        /// <returns></returns>
        public List<ReportComponentJewelryViewModel> GetComponentJewelry()
        {
            var components = _componentStorage.GetFullList();
            var jewelrys = _jewelryStorage.GetFullList();
            var list = new List<ReportComponentJewelryViewModel>();
            foreach (var jewelry in jewelrys)
            {
                var record = new ReportComponentJewelryViewModel
                {
                    JewelryName = jewelry.JewelryName,
                    Components = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var component in components)
                {
                    if (jewelry.JewelryComponents.ContainsKey(component.Id))
                    {
                        record.Components.Add(new Tuple<string, int>(component.ComponentName,
                        jewelry.JewelryComponents[component.Id].Item2));
                        record.TotalCount += jewelry.JewelryComponents[component.Id].Item2;
                    }
                }
                list.Add(record);
            }
            return list;
        }
        /// <summary>
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return _orderStorage.GetFilteredList(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                JewelryName = x.JewelryName,
                Count = x.Count,
                Sum = x.Sum,
                Status = ((OrderStatus)Enum.Parse(typeof(OrderStatus), x.Status.ToString())).ToString()
            })
            .ToList();
        }
        /// <summary>
        /// Сохранение изделия в файл-Word
        /// </summary>
        /// <param name="model"></param>
        public void SaveJewelrysToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список изделий",
                Jewelrys = _jewelryStorage.GetFullList()
            });
        }
        /// <summary>
        /// Сохранение компонент с указаеним продуктов в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        public void SaveComponentJewelryToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список изделий",
                ComponentJewelrys = GetComponentJewelry()
            });
        }
        /// <summary>
        /// Сохранение заказов в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Orders = GetOrders(model)
            });
        }
    }
}

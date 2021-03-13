using JewelryShopBusinessLogic.BindingModels;
using JewelryShopBusinessLogic.Interfaces;
using JewelryShopBusinessLogic.ViewModels;
using JewelryShopListImplements.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JewelryShopListImplements.Implements
{
    public class JewelryStorage : IJewelryStorage
    {
        private readonly DataListSingleton source;
        public JewelryStorage()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<JewelryViewModel> GetFullList()
        {
            List<JewelryViewModel> result = new List<JewelryViewModel>();
            foreach (var component in source.Jewelrys)
            {
                result.Add(CreateModel(component));
            }
            return result;
        }
        public List<JewelryViewModel> GetFilteredList(JewelryBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            List<JewelryViewModel> result = new List<JewelryViewModel>();
            foreach (var jewelry in source.Jewelrys)
            {
                if (jewelry.JewelryName.Contains(model.JewelryName))
                {
                    result.Add(CreateModel(jewelry));
                }
            }
            return result;
        }
        public JewelryViewModel GetElement(JewelryBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var jewelry in source.Jewelrys)
            {
                if (jewelry.Id == model.Id || jewelry.JewelryName ==
                model.JewelryName)
                {
                    return CreateModel(jewelry);
                }
            }
            return null;
        }

        public void Insert(JewelryBindingModel model)
        {
            Jewelry tempJewelry = new Jewelry
            {
                Id = 1,
                JewelryComponents = new
            Dictionary<int, int>()
            };
            foreach (var jewelry in source.Jewelrys)
            {
                if (jewelry.Id >= tempJewelry.Id)
                {
                    tempJewelry.Id = jewelry.Id + 1;
                }
            }
            source.Jewelrys.Add(CreateModel(model, tempJewelry));
        }
        public void Update(JewelryBindingModel model)
        {
            Jewelry tempJewelry = null;
            foreach (var jewelry in source.Jewelrys)
            {
                if (jewelry.Id == model.Id)
                {
                    tempJewelry = jewelry;
                }
            }
            if (tempJewelry == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempJewelry);
        }
        public void Delete(JewelryBindingModel model)
        {
            for (int i = 0; i < source.Jewelrys.Count; ++i)
            {
                if (source.Jewelrys[i].Id == model.Id)
                {
                    source.Jewelrys.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private Jewelry CreateModel(JewelryBindingModel model, Jewelry jewelry)
        {
            jewelry.JewelryName = model.JewelryName;
            jewelry.Price = model.Price;
            // удаляем убранные
            foreach (var key in jewelry.JewelryComponents.Keys.ToList())
            {
                if (!model.JewelryComponents.ContainsKey(key))
                {
                    jewelry.JewelryComponents.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var component in model.JewelryComponents)
            {
                if (jewelry.JewelryComponents.ContainsKey(component.Key))
                {
                    jewelry.JewelryComponents[component.Key] =
                    model.JewelryComponents[component.Key].Item2;
                }
                else
                {
                    jewelry.JewelryComponents.Add(component.Key,
                    model.JewelryComponents[component.Key].Item2);
                }
            }
            return jewelry;
        }
        private JewelryViewModel CreateModel(Jewelry jewelry)
        {
            // требуется дополнительно получить список компонентов для изделия с
            //названиями и их количество
            Dictionary<int, (string, int)> jewelryComponents = new
            Dictionary<int, (string, int)>();
            foreach (var pc in jewelry.JewelryComponents)
            {
                string componentName = string.Empty;
                foreach (var component in source.Components)
                {
                    if (pc.Key == component.Id)
                    {
                        componentName = component.ComponentName;
                        break;
                    }
                }
                jewelryComponents.Add(pc.Key, (componentName, pc.Value));
            }
            return new JewelryViewModel
            {
                Id = jewelry.Id,
                JewelryName = jewelry.JewelryName,
                Price = jewelry.Price,
                JewelryComponents = jewelryComponents
            };

        }
    }
}

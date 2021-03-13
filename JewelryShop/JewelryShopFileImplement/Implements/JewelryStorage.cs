using JewelryShopBusinessLogic.BindingModels;
using JewelryShopBusinessLogic.Interfaces;
using JewelryShopBusinessLogic.ViewModels;
using JewelryShopFileImplements.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JewelryShopFileImplement.Implements
{
    public class JewelryStorage : IJewelryStorage
    {
        private readonly FileDataListSingleton source;

        public JewelryStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public List<JewelryViewModel> GetFullList()
        {
            return source.Jewelrys.Select(CreateModel).ToList();
        }

        public List<JewelryViewModel> GetFilteredList(JewelryBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.Jewelrys.Where(rec => rec.JewelryName.Contains(model.JewelryName))
                .Select(CreateModel).ToList();
        }

        public JewelryViewModel GetElement(JewelryBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var jewelry = source.Jewelrys
                .FirstOrDefault(rec => rec.JewelryName == model.JewelryName || rec.Id == model.Id);
            return jewelry != null ? CreateModel(jewelry) : null;
        }

        public void Insert(JewelryBindingModel model)
        {
            int maxId = source.Jewelrys.Count > 0 ? source.Components.Max(rec => rec.Id) : 0;
            var element = new Jewelry
            {
                Id = maxId + 1,
                JewelryComponents = new Dictionary<int, int>()
            };
            source.Jewelrys.Add(CreateModel(model, element));
        }

        public void Update(JewelryBindingModel model)
        {
            var element = source.Jewelrys.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
        }

        public void Delete(JewelryBindingModel model)
        {
            Jewelry element = source.Jewelrys.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Jewelrys.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
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
            return new JewelryViewModel
            {
                Id = jewelry.Id,
                JewelryName = jewelry.JewelryName,
                Price = jewelry.Price,
                JewelryComponents = jewelry.JewelryComponents
                    .ToDictionary(recPC => recPC.Key, recPC =>
                    (source.Components.FirstOrDefault(recC => recC.Id ==
                    recPC.Key)?.ComponentName, recPC.Value))
            };
        }
    }
}

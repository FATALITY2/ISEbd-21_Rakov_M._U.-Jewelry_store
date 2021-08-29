using System;
using JewelryShopBusinessLogic.Interfaces;
using JewelryShopBusinessLogic.ViewModels;
using JewelryShopBusinessLogic.BindingModels;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using JewelryShopDatabaseImplement.Models;

namespace JewelryShopDatabaseImplement.Implements
{
    public class JewelryStorage : IJewelryStorage
    {
        public List<JewelryViewModel> GetFullList()
        {
            using (var context = new JewelryShopDatabase())
            {
                return context.Jewelrys
                .Include(rec => rec.JewelryComponent)
                .ThenInclude(rec => rec.Component)
                .ToList()
                .Select(rec => new JewelryViewModel
                {
                    Id = rec.Id,
                    JewelryName = rec.JewelryName,
                    Price = rec.Price,
                    JewelryComponents = rec.JewelryComponent
                .ToDictionary(recPC => recPC.ComponentId, recPC =>
                (recPC.Component?.ComponentName, recPC.Count))
                })
                .ToList();
            }
        }

        public List<JewelryViewModel> GetFilteredList(JewelryBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new JewelryShopDatabase())
            {
                return context.Jewelrys
                .Include(rec => rec.JewelryComponent)
                .ThenInclude(rec => rec.Component)
                .Where(rec => rec.JewelryName.Contains(model.JewelryName))
                .ToList()
                .Select(rec => new JewelryViewModel
                {
                    Id = rec.Id,
                    JewelryName = rec.JewelryName,
                    Price = rec.Price,
                    JewelryComponents = rec.JewelryComponent
                .ToDictionary(recPC => recPC.ComponentId, recPC =>
                (recPC.Component?.ComponentName, recPC.Count))
                })
                .ToList();
            }
        }

        public JewelryViewModel GetElement(JewelryBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new JewelryShopDatabase())
            {
                var product = context.Jewelrys
                .Include(rec => rec.JewelryComponent)
                .ThenInclude(rec => rec.Component)
                .FirstOrDefault(rec => rec.JewelryName.Equals(model.JewelryName) || rec.Id
                == model.Id);
                return product != null ?
                new JewelryViewModel
                {
                    Id = product.Id,
                    JewelryName = product.JewelryName,
                    Price = product.Price,
                    JewelryComponents = product.JewelryComponent
                .ToDictionary(recPC => recPC.ComponentId, recPC =>
                (recPC.Component?.ComponentName, recPC.Count))
                } : null;
            }
        }

        public void Insert(JewelryBindingModel model)
        {
            using (var context = new JewelryShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Jewelry jewelry = CreateModel(model, new Jewelry());
                        context.Jewelrys.Add(jewelry);
                        context.SaveChanges();
                        CreateModel(model, jewelry, context);

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Update(JewelryBindingModel model)
        {
            using (var context = new JewelryShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.Jewelrys.FirstOrDefault(rec => rec.Id ==
                        model.Id);
                        if (element == null)
                        {
                            throw new Exception("Элемент не найден");
                        }
                        CreateModel(model, element, context);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Delete(JewelryBindingModel model)
        {
            using (var context = new JewelryShopDatabase())
            {
                Jewelry element = context.Jewelrys.FirstOrDefault(rec => rec.Id ==
                model.Id);
                if (element != null)
                {
                    context.Jewelrys.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        private Jewelry CreateModel(JewelryBindingModel model, Jewelry jewelry)
        {
            jewelry.JewelryName = model.JewelryName;
            jewelry.Price = model.Price;
            return jewelry;
        }

        private Jewelry CreateModel(JewelryBindingModel model, Jewelry jewelry,
        JewelryShopDatabase context)
        {
            jewelry.JewelryName = model.JewelryName;
            jewelry.Price = model.Price;
            if (model.Id.HasValue)
            {
                var productComponents = context.JewelryComponents.Where(rec =>
                rec.JewelryId == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.JewelryComponents.RemoveRange(productComponents.Where(rec =>
                !model.JewelryComponents.ContainsKey(rec.ComponentId)).ToList());
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateComponent in productComponents)
                {
                    updateComponent.Count =
                    model.JewelryComponents[updateComponent.ComponentId].Item2;
                    model.JewelryComponents.Remove(updateComponent.ComponentId);
                }
                context.SaveChanges();
            }
            // добавили новые
            foreach (var pc in model.JewelryComponents)
            {
                context.JewelryComponents.Add(new JewelryComponent
                {
                    JewelryId = jewelry.Id,
                    ComponentId = pc.Key,
                    Count = pc.Value.Item2,
                });
                context.SaveChanges();
            }
            return jewelry;
        }
    }
}

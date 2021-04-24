using System;
using System.Collections.Generic;
using System.Text;
using JewelryShopBusinessLogic.Interfaces;
using JewelryShopBusinessLogic.ViewModels;
using JewelryShopBusinessLogic.BindingModels;
using System.Linq;
using JewelryShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace JewelryShopDatabaseImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        public List<OrderViewModel> GetFullList()
        {
            using (var context = new JewelryShopDatabase())
            {
                return context.Orders.Include(rec => rec.Jewelry).Include(rec => rec.Client).Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    JewelryName = rec.Jewelry.JewelryName,
                    JewelryId = rec.JewelryId,
                    Count = rec.Count,
                    Sum = rec.Sum,
                    Status = rec.Status,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement,
                    ClientId = rec.ClientId,
                    ClientFIO = rec.Client.ClientFIO
                })
                .ToList();
            }
        }

        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new JewelryShopDatabase())
            {
                return context.Orders.Include(rec => rec.Jewelry).Include(rec => rec.Client)
                .Where(rec => (model.ClientId.HasValue && rec.ClientId == model.ClientId) || (!model.DateFrom.HasValue && !model.DateTo.HasValue && rec.DateCreate == model.DateCreate) ||
                (model.DateFrom.HasValue && model.DateTo.HasValue && rec.DateCreate.Date
                >= model.DateFrom.Value.Date && rec.DateCreate.Date <= model.DateTo.Value.Date))
                .Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    JewelryName = rec.Jewelry.JewelryName,
                    JewelryId = rec.JewelryId,
                    Count = rec.Count,
                    Sum = rec.Sum,
                    Status = rec.Status,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement,
                    ClientId = rec.ClientId,
                    ClientFIO = rec.Client.ClientFIO
                })
                .ToList();
            }
        }

        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new JewelryShopDatabase())
            {
                var order = context.Orders.Include(rec => rec.Jewelry).Include(rec => rec.Client)
                .FirstOrDefault(rec => rec.Id == model.Id);
                return order != null ?
                new OrderViewModel
                {
                    Id = order.Id,
                    JewelryName = order.Jewelry.JewelryName,
                    JewelryId = order.JewelryId,
                    Count = order.Count,
                    Sum = order.Sum,
                    Status = order.Status,
                    DateCreate = order.DateCreate,
                    DateImplement = order.DateImplement,
                    ClientId = order.ClientId,
                    ClientFIO = order.Client.ClientFIO
                } :
                null;
            }
        }

        public void Insert(OrderBindingModel model)
        {
            using (var context = new JewelryShopDatabase())
            {
                context.Orders.Add(CreateModel(model, new Order()));
                context.SaveChanges();
            }
        }

        public void Update(OrderBindingModel model)
        {
            using (var context = new JewelryShopDatabase())
            {
                var element = context.Orders.FirstOrDefault(rec => rec.Id ==
                model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        public void Delete(OrderBindingModel model)
        {
            using (var context = new JewelryShopDatabase())
            {
                Order element = context.Orders.FirstOrDefault(rec => rec.Id ==
                model.Id);
                if (element != null)
                {
                    context.Orders.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        private Order CreateModel(OrderBindingModel model, Order order)
        {
            order.JewelryId = model.JewelryId;
            order.Count = model.Count;
            order.Sum = model.Sum;
            order.Status = model.Status;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            order.ClientId = (int)model.ClientId;
            return order;
        }
    }
}


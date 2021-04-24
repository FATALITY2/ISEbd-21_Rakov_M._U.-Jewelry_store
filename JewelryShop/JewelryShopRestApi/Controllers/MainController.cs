using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JewelryShopBusinessLogic.BuisnessLogics;
using JewelryShopBusinessLogic.ViewModels;
using JewelryShopBusinessLogic.BindingModels;

namespace JewelryShopRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly OrderLogic _order;
        private readonly JewelryLogic _jewelry;
        private readonly OrderLogic _main;
        public MainController(OrderLogic order, JewelryLogic jewelry, OrderLogic main)
        {
            _order = order;
            _jewelry = jewelry;
            _main = main;
        }
        [HttpGet]
        public List<JewelryViewModel> GetJewelryList() => _jewelry.Read(null)?.ToList();

        [HttpGet]
        public JewelryViewModel GetJewelry(int jewelryId) => _jewelry.Read(new JewelryBindingModel { Id = jewelryId })?[0];

        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new OrderBindingModel { ClientId = clientId });

        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) => _main.CreateOrder(model);
    }
}

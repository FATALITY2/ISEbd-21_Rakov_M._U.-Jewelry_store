using System;
using System.Collections.Generic;
using JewelryShopBusinessLogic.BindingModels;
using JewelryShopBusinessLogic.ViewModels;
using System.Text;

namespace JewelryShopBusinessLogic.Interfaces
{
    public interface IWarehouseStorage
    {
        List<WarehouseViewModel> GetFullList();

        List<WarehouseViewModel> GetFilteredList(WarehouseBindingModel model);

        WarehouseViewModel GetElement(WarehouseBindingModel model);

        void Insert(WarehouseBindingModel model);

        void Update(WarehouseBindingModel model);

        void Delete(WarehouseBindingModel model);
    }
}
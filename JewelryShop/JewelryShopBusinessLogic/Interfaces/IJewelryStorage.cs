using JewelryShopBusinessLogic.BindingModels;
using JewelryShopBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace JewelryShopBusinessLogic.Interfaces
{
    public interface IJewelryStorage
    {
        List<JewelryViewModel> GetFullList();

        List<JewelryViewModel> GetFilteredList(JewelryBindingModel model);

        JewelryViewModel GetElement(JewelryBindingModel model);

        void Insert(JewelryBindingModel model);

        void Update(JewelryBindingModel model);

        void Delete(JewelryBindingModel model);
    }
}

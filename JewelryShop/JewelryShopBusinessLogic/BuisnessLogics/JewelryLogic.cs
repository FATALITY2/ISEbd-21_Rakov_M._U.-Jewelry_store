using JewelryShopBusinessLogic.BindingModels;
using JewelryShopBusinessLogic.Enums;
using JewelryShopBusinessLogic.Interfaces;
using JewelryShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;


namespace JewelryShopBusinessLogic.BuisnessLogics
{
    public class JewelryLogic
    {
        private readonly IJewelryStorage _jewelryStorage;
        public JewelryLogic(IJewelryStorage componentStorage)
        {
            _jewelryStorage = componentStorage;
        }

        public List<JewelryViewModel> Read(JewelryBindingModel model)
        {
            if (model == null)
            {
                return _jewelryStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<JewelryViewModel> { _jewelryStorage.GetElement(model) };
            }
            return _jewelryStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(JewelryBindingModel model)
        {
            var element = _jewelryStorage.GetElement(new JewelryBindingModel
            {
                JewelryName = model.JewelryName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть компонент с таким названием");
            }
            if (model.Id.HasValue)
            {
                _jewelryStorage.Update(model);
            }
            else
            {
                _jewelryStorage.Insert(model);
            }
        }
        public void Delete(JewelryBindingModel model)
        {
            var element = _jewelryStorage.GetElement(new JewelryBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _jewelryStorage.Delete(model);
        }
    }
}

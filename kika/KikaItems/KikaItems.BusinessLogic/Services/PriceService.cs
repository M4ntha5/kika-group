using KikaItems.Contracts.Entities;
using KikaItems.Contracts.Interfaces.Repositories;
using KikaItems.Contracts.Interfaces.Services;
using KikaItems.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KikaItems.BusinessLogic.Services
{
    public class PriceService : IPriceService
    {
        private readonly IPriceRepository _priceRepository;

        public PriceService(IPriceRepository priceRepository)
        {
            _priceRepository = priceRepository;
        }

        public Task InsertPrice(string sku, InsertPrice price)
        {
            if (price == null || string.IsNullOrEmpty(sku))
                throw new Exception("Cannot add price, because price is null or item sku not defined");

            return _priceRepository.InsertPrice(sku, price);
        }

        public Task<List<PriceEntity>> GetAllItemPrices(string sku)
        {
            if (string.IsNullOrEmpty(sku))
                throw new Exception("Sku not defined");

            return _priceRepository.GetAllItemPrices(sku);
        }

        public Task UpdateSelectedPrice(int priceId, InsertPrice updatedItem)
        {
            return _priceRepository.UpdateSelectedPrice(priceId, updatedItem);
        }

        public Task UpdateSelectedPriceState(int priceId, bool state)
        {
            return _priceRepository.ChangeActiveState(priceId, state);
        }

    }
}

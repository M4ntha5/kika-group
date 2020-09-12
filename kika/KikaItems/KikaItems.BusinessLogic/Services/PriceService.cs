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

        public Task UpdateSelectedPrice(string sku, int priceId, InsertPrice updatedItem)
        {
            return _priceRepository.UpdateSelectedPrice(sku, priceId, updatedItem);
        }

        public Task UpdateSelectedPriceState(string sku, int priceId)
        {
            return _priceRepository.ChangeActiveState(sku, priceId);
        }

        public async Task<InsertPrice> GetSelectedPrice(string sku, int priceId)
        {
            if (string.IsNullOrEmpty(sku) || priceId < 1)
                throw new Exception("Invalid data");

            var price = await _priceRepository.GetSelectedPrice(sku, priceId);

            var model = new InsertPrice()
            {
                Active = price.Active,
                Price = price.Price.ToString()
            };
            return model;
        }

    }
}

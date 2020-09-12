using KikaItems.Contracts.Entities;
using KikaItems.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KikaItems.Contracts.Interfaces.Services
{
    public interface IPriceService
    {
        Task InsertPrice(string sku, InsertPrice price);
        Task<List<PriceEntity>> GetAllItemPrices(string sku);
        Task UpdateSelectedPrice(string sku, int priceId, InsertPrice updatedItem);
        Task UpdateSelectedPriceState(string sku, int priceId);
        Task<InsertPrice> GetSelectedPrice(string sku, int priceId);
    }
}

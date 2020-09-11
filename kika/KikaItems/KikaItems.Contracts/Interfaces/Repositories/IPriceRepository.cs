using KikaItems.Contracts.Entities;
using KikaItems.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KikaItems.Contracts.Interfaces.Repositories
{
    public interface IPriceRepository
    {
        Task InsertPrice(string sku, InsertPrice price);
        Task<List<PriceEntity>> GetAllItemPrices(string sku);
        Task UpdateSelectedPrice(int priceId, InsertPrice updatedItem);
        Task ChangeActiveState(int priceId, bool activeState);
    }
}

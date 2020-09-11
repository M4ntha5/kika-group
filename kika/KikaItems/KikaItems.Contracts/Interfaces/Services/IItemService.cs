using KikaItems.Contracts.Entities;
using KikaItems.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KikaItems.Contracts.Interfaces.Services
{
    public interface IItemService
    {
        Task InsertItem(ItemEntity item);
        Task<List<Item>> GetAllItems();
        Task<Item> GetSelectedItem(string sku);
        Task UpdateSelectedItem(string sku, UpdateItem item);
        Task DeleteSelectedItem(string sku);
    }
}

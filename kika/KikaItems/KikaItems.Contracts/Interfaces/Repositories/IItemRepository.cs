using KikaItems.Contracts.Entities;
using KikaItems.Contracts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KikaItems.Contracts.Interfaces.Repositories
{
    public interface IItemRepository
    {
        Task InsertItem(UpdateItem item);
        Task<List<Item>> GetAllItems();
        Task UpdateSelectedItem(string sku, UpdateItem updatedItem);
        Task<Item> GetItemBySku(string sku);
        Task DeleteSelectedItem(string sku);
    }
}

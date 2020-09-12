using KikaItems.Contracts;
using KikaItems.Contracts.Entities;
using KikaItems.Contracts.Interfaces;
using KikaItems.Contracts.Interfaces.Repositories;
using KikaItems.Contracts.Interfaces.Services;
using KikaItems.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KikaItems.BusinessLogic.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task InsertItem(UpdateItem item)
        {
            if (item == null)
                throw new Exception("Cannot add item, because item is not defined");

            //check if sku already exists
            var entity = await _itemRepository.GetItemBySku(item.Sku);
            if (entity != null)
                throw new Exception("Item with such sku already exists");

            await _itemRepository.InsertItem(item);
        }

        public Task<List<Item>> GetAllItems()
        { 
            return _itemRepository.GetAllItems();
        }

        public Task<Item> GetSelectedItem(string sku)
        {
            if (string.IsNullOrEmpty(sku))
                throw new Exception("Sku is not defind");

            return _itemRepository.GetItemBySku(sku);
        }

        public Task UpdateSelectedItem(string sku, UpdateItem item)
        {
            if (string.IsNullOrEmpty(sku))
                throw new Exception("Sku is not defind");

            return _itemRepository.UpdateSelectedItem(sku, item);
        }

        public Task DeleteSelectedItem(string sku)
        {
            if (string.IsNullOrEmpty(sku))
                throw new Exception("Sku is not defind");

            return _itemRepository.DeleteSelectedItem(sku);
        }
    }
}

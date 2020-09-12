using KikaItems.Contracts;
using KikaItems.Contracts.Entities;
using KikaItems.Contracts.Interfaces;
using KikaItems.Contracts.Interfaces.Repositories;
using KikaItems.Contracts.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KikaItems.BusinessLogic.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly KikaDatabaseContext _context;
        public ItemRepository(KikaDatabaseContext context)
        {
            _context = context;
        }

        public async Task InsertItem(ItemEntity item)
        {
            if (string.IsNullOrEmpty(item.Ean) || string.IsNullOrEmpty(item.Name) || string.IsNullOrEmpty(item.Sku))
                throw new Exception("Cannot add item, because name, ean or sku is not defined");

            var entity = new ItemEntity
            {
                Name = item.Name,
                Ean = item.Ean,
                Sku = item.Sku.ToUpper(),
                UnitOfMeasureId = item.UnitOfMeasureId
            };

            await _context.Items.AddAsync(entity);
        }

        public Task<List<Item>> GetAllItems()
        {
            return _context.Items
                .Join(_context.UnitsOfMeasure,
                      item => item.UnitOfMeasureId,
                      unit => unit.Id,
                      (item, unit) => new Item
                      {
                          Name = item.Name,
                          Ean = item.Ean,
                          Sku = item.Sku.ToUpper(),
                          UnitOfMeasureName = unit.Name
                      })
                .ToListAsync();
        }

        public async Task UpdateSelectedItem(string sku, UpdateItem updatedItem)
        {
            var entity = await _context.Items.Where(x => x.Sku.ToUpper() == sku.ToUpper()).FirstOrDefaultAsync();

            if(entity == null)
                throw new Exception("Item you are trying to update does not exist");

            entity.Name = updatedItem.Name;
            entity.Ean = updatedItem.Ean;
            entity.UnitOfMeasureId = updatedItem.UnitOfMeasureId;
        }

        public Task<Item> GetItemBySku(string sku)
        {
            return _context.Items
                .Where(x => x.Sku.ToUpper() == sku.ToUpper())
                .Join(_context.UnitsOfMeasure, 
                      item => item.UnitOfMeasureId,
                      unit => unit.Id,
                      (item, unit) => new Item
                      {
                          Name = item.Name,
                          Ean = item.Ean,
                          Sku = item.Sku.ToUpper(),
                          UnitOfMeasureName = unit.Name
                      })
                .FirstOrDefaultAsync();
        }

        public async Task DeleteSelectedItem(string sku)
        {
            var entity = await _context.Items.Where(x => x.Sku.ToUpper() == sku.ToUpper()).FirstOrDefaultAsync();
            if (entity == null)
                throw new Exception("Item you are trying to delete does not exist");

            _context.Items.Remove(entity);
        }

    }
}

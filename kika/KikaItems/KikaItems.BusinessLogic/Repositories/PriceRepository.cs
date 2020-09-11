﻿using KikaItems.Contracts;
using KikaItems.Contracts.Entities;
using KikaItems.Contracts.Interfaces.Repositories;
using KikaItems.Contracts.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KikaItems.BusinessLogic.Repositories
{
    public class PriceRepository : IPriceRepository
    {
        private readonly KikaDatabaseContext _context;
        public PriceRepository(KikaDatabaseContext context)
        {
            _context = context;
        }

        public async Task InsertPrice(string sku, InsertPrice price)
        {
            if (price == null)
                throw new Exception("Cannot add price, because price is null");

            var entity = new PriceEntity
            {
                Active = price.Active,
                ItemSku = sku,
                Price = price.Price
            };

            await _context.Prices.AddAsync(entity);
        }

        public Task<List<PriceEntity>> GetAllItemPrices(string sku)
        {
            return _context.Prices.Where(x => x.ItemSku == sku).ToListAsync();
        }

        public async Task UpdateSelectedPrice(int priceId, InsertPrice updatedItem)
        {
            var entity = await _context.Prices.FindAsync(priceId);

            if (entity == null)
                throw new Exception("Price you are trying to update does not exist");

            entity.Active = updatedItem.Active;
            entity.Price = updatedItem.Price;
        }

        public async Task ChangeActiveState(int priceId, bool activeState)
        {
            var entity = await _context.Prices.FindAsync(priceId);

            if (entity == null)
                throw new Exception("Price you are trying to update does not exist");

            entity.Active = activeState;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using KikaItems.BusinessLogic.Services;
using KikaItems.Contracts;
using KikaItems.Contracts.Entities;
using KikaItems.Contracts.Interfaces.Services;
using KikaItems.Contracts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KikaItems.WebApi.Controllers
{
    [Route("api/items")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _itemService;
        private readonly KikaDatabaseContext _context;

        public ItemsController(IItemService itemService, KikaDatabaseContext context)
        {
            _itemService = itemService;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var items = await _itemService.GetAllItems();
            if (items == null || items.Count < 1)
                throw new Exception("No items found");

            return Ok(items);
        }

        [HttpGet("{sku}")]
        public async Task<IActionResult> Get(string sku)
        {
            var item = await _itemService.GetSelectedItem(sku);
            if (item == null)
                throw new Exception("Item not found");

            return Ok(item);
        }

        [HttpPost()]
        public async Task<IActionResult> Post([Required, FromForm] ItemEntity newItem)
        {
            if (newItem == null || string.IsNullOrEmpty(newItem.Ean) || string.IsNullOrEmpty(newItem.Sku)
                || string.IsNullOrEmpty(newItem.Name))
                throw new Exception("Some fields are missing");

            await _itemService.InsertItem(newItem);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{sku}")]
        public async Task<IActionResult> Update([Required] string sku, [Required, FromForm] UpdateItem updatedItem)
        {
            if (updatedItem == null || string.IsNullOrEmpty(updatedItem.Ean) ||
                string.IsNullOrEmpty(updatedItem.Name) || string.IsNullOrEmpty(sku))
                throw new Exception("Some item fields are missing");

            await _itemService.UpdateSelectedItem(sku, updatedItem);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{sku}")]
        public async Task<IActionResult> Delete([Required] string sku)
        {
            if (string.IsNullOrEmpty(sku))
                throw new Exception("Some item fields are missing");

            await _itemService.DeleteSelectedItem(sku);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}

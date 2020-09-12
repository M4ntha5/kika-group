using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using KikaItems.Contracts;
using KikaItems.Contracts.Interfaces.Services;
using KikaItems.Contracts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KikaItems.WebApi.Controllers
{
    [Route("api/items/{sku}/prices")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        private readonly IPriceService _priceService;
        private readonly KikaDatabaseContext _context;

        public PriceController(IPriceService priceService, KikaDatabaseContext context)
        {
            _priceService = priceService;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string sku)
        {
            if (string.IsNullOrEmpty(sku))
                throw new Exception("Sku no defined");

            var prices = await _priceService.GetAllItemPrices(sku);
            if (prices == null || prices.Count < 1)
                throw new Exception("No prices found for this sku");

            return Ok(prices);
        }

        [HttpPost]
        public async Task<IActionResult> Post(string sku, [Required, FromForm] InsertPrice insertPrice)
        {
            if (insertPrice == null || insertPrice.Price < 1 || string.IsNullOrEmpty(sku))
                throw new Exception("Invalid information entered");

            await _priceService.InsertPrice(sku, insertPrice);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{priceId}")]
        public async Task<IActionResult> Update(string sku, int priceId, [Required, FromForm] InsertPrice insertPrice)
        {
            if (insertPrice == null || insertPrice.Price < 1 || priceId < 1 || string.IsNullOrEmpty(sku))
                throw new Exception("Invalid information entered");

            await _priceService.UpdateSelectedPrice(sku, priceId, insertPrice);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{priceId}/state")]
        public async Task<IActionResult> Update(string sku, int priceId, [Required, FromForm] bool activeState)
        {
            if (priceId < 1 || string.IsNullOrEmpty(sku))
                throw new Exception("Invalid information entered");

            await _priceService.UpdateSelectedPriceState(sku, priceId, activeState);
            await _context.SaveChangesAsync();
            return Ok();
        }


    }
}

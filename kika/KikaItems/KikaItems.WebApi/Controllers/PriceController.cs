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

        [HttpGet("{priceId}")]
        public async Task<IActionResult> Get(string sku, int priceId)
        {
            if (string.IsNullOrEmpty(sku))
                throw new Exception("Sku no defined");

            var price = await _priceService.GetSelectedPrice(sku, priceId);
            if (price == null)
                throw new Exception("Such price does not exist");

            return Ok(price);
        }

        [HttpPost]
        public async Task<IActionResult> Post(string sku, [Required, FromBody] InsertPrice insertPrice)
        {
            if (insertPrice == null || decimal.Parse(insertPrice.Price) < 1 || string.IsNullOrEmpty(sku))
                throw new Exception("Invalid information entered");

            await _priceService.InsertPrice(sku, insertPrice);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{priceId}")]
        public async Task<IActionResult> Update(string sku, int priceId, [FromBody] InsertPrice insertPrice)
        {
            if (insertPrice == null || decimal.Parse(insertPrice.Price) < 1 || priceId < 1 || string.IsNullOrEmpty(sku))
                throw new Exception("Invalid information entered");
    
            await _priceService.UpdateSelectedPrice(sku, priceId, insertPrice);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("{priceId}/state")]
        public async Task<IActionResult> ChangeActiveState(string sku, int priceId)
        {
            if (priceId < 1 || string.IsNullOrEmpty(sku))
                throw new Exception("Invalid information entered");

            await _priceService.UpdateSelectedPriceState(sku, priceId);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}

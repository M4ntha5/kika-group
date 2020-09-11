using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KikaItems.Contracts;
using KikaItems.Contracts.Interfaces.Services;
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
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        [HttpGet("{priceId}")]
        public async Task<IActionResult> Get(string priceId)
        {
            return Ok();
        }

    }
}

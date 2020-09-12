using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KikaItems.Contracts.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KikaItems.WebApi.Controllers
{
    [Route("api/unitsOfMeasure")]
    [ApiController]
    public class UnitOfMeasureController : ControllerBase
    {
        private readonly IUnitOfMeasureRepository _unitOfMeasureRepository;

        public UnitOfMeasureController(IUnitOfMeasureRepository unitOfMeasureRepository)
        {
            _unitOfMeasureRepository = unitOfMeasureRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var units = await _unitOfMeasureRepository.GetUnitsOfMeasure();
            if (units == null || units.Count < 1)
                throw new Exception("No units found");

            var formatedUnits = units.Select(x => x.Name).ToList();

            return Ok(formatedUnits);
        }
    }
}

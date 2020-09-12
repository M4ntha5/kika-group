using KikaItems.Contracts;
using KikaItems.Contracts.Entities;
using KikaItems.Contracts.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KikaItems.BusinessLogic.Repositories
{
    public class UnitOfMeasureRepository : IUnitOfMeasureRepository
    {
        private readonly KikaDatabaseContext _context;
        public UnitOfMeasureRepository(KikaDatabaseContext context)
        {
            _context = context;
        }

        public Task<List<UnitsOfMeasureEntity>> GetUnitsOfMeasure()
        {
            return _context.UnitsOfMeasure.ToListAsync();
        }


    }
}

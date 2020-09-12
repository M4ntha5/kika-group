using KikaItems.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KikaItems.Contracts.Interfaces.Repositories
{
    public interface IUnitOfMeasureRepository
    {
        Task<List<UnitsOfMeasureEntity>> GetUnitsOfMeasure();
    }
}

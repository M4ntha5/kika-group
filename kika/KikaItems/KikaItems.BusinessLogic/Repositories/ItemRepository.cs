using KikaItems.Contracts;
using KikaItems.Contracts.Entities;
using KikaItems.Contracts.Interfaces;
using KikaItems.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;
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



    }
}

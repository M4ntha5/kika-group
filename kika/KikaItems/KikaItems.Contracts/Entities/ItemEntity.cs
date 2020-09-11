using System;
using System.Collections.Generic;

namespace KikaItems.Contracts.Entities
{
    public partial class ItemEntity
    {
        public string Sku { get; set; }
        public string Ean { get; set; }
        public string Name { get; set; }
        public int UnitOfMeasureId { get; set; }
    }
}

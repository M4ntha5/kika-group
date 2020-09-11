using System;
using System.Collections.Generic;

namespace KikaItems.Contracts.Entities
{
    public partial class PriceEntity
    {
        public int Id { get; set; }
        public string ItemSku { get; set; }
        public decimal Price { get; set; }
        public bool? Active { get; set; }
    }
}

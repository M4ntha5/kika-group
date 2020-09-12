using System;
using System.Collections.Generic;
using System.Text;

namespace KikaItems.Contracts.Models
{
    public class UpdateItem
    {
        public string Sku { get; set; }
        public string Ean { get; set; }
        public string Name { get; set; }
        public string UnitOfMeasure { get; set; }
    }
}

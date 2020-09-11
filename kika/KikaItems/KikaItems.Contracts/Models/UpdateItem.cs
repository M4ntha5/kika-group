using System;
using System.Collections.Generic;
using System.Text;

namespace KikaItems.Contracts.Models
{
    public class UpdateItem
    {
        public string Ean { get; set; }
        public string Name { get; set; }
        public int UnitOfMeasureId { get; set; }
    }
}

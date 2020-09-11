using System;
using System.Collections.Generic;
using System.Text;

namespace KikaItems.Contracts.Models
{
    public class Item
    { 
         public string Sku { get; set; }
         public string Ean { get; set; }
         public string Name { get; set; }
         public string UnitOfMeasureName { get; set; }
    }
}

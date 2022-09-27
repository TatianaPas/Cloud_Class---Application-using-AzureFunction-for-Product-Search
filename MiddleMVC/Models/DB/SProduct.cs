using System;
using System.Collections.Generic;

namespace MiddleMVC.Models.DB
{
    public partial class SProduct
    {
        public SProduct()
        {
            
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }


    }
}

using System;
using System.Collections.Generic;

namespace MiddleMVC.Models.DB
{
    public partial class CurrentProductList
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
    }
}

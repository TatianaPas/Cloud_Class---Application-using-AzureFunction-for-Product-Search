using System;
using System.Collections.Generic;

namespace MiddleMVC.Models.DB
{
    public partial class TblFlower
    {
        public Guid FlowerId { get; set; }
        public string? FlowerName { get; set; }
        public byte[]? Flower { get; set; }
    }
}

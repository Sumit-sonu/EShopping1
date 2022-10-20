using System;
using System.Collections.Generic;

#nullable disable

namespace ITCStore.Models
{
    public partial class OrderDetail
    {
        public int OrderDetailsId { get; set; }
        public int? ProductId { get; set; }
        public int? ProductQty { get; set; }
        public double? ProductPrice { get; set; }
        public string OrderId { get; set; }
        public double? Subtotal { get; set; }
    }
}

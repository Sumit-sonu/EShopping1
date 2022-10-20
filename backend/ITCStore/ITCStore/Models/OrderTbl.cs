using System;
using System.Collections.Generic;

#nullable disable

namespace ITCStore.Models
{
    public partial class OrderTbl
    {
        public string OrderId { get; set; }
        public int OrderNo { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? OrderTotal { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? ShippingDate { get; set; }
        public string IsDelivered { get; set; }
    }
}

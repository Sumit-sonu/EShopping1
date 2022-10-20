using System;
using System.Collections.Generic;

#nullable disable

namespace ITCStore.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public double? Price { get; set; }
        public int? Stock { get; set; }
        public int CategoryId { get; set; }
    }
}

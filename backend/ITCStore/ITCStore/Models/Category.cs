using System;
using System.Collections.Generic;

#nullable disable

namespace ITCStore.Models
{
    public partial class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryImage { get; set; }
        public string CategoryDescription { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutopartStore2.Models
{
    public class Autopart
    {
        public int AutopartId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public string Category { get; set; }
    }
}
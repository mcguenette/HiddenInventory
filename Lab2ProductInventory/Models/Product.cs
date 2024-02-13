using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2ProductInventory.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }

        public Product()
        {

        }
    }
}
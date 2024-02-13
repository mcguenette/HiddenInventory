using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2ProductInventory.Models
{
    public class Inventory
    {
        public int InventoryID { get; set; }
        public int ProductID { get; set; } // Foreign key to Product's ProductID
        public int StockQuantity { get; set; }
        
        public Inventory() 
        { 
            
        }  
    }
}
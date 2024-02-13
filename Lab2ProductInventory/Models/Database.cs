using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2ProductInventory.Models
{
    public class Database
    {
        // Add a method to generate unique IDs for products and inventory
        private int productIDCounter = 6; // Start from 6 to avoid conflicts with existing data
        private int inventoryIDCounter = 6;

        public List<Product> ProductsCollection = new List<Product>() 
        {
            new Product() { ProductID = 1, ProductName = "Google Pixel 7", ProductDescription = "High-end smartphone with advanced features", ProductPrice = 999.99m },
            new Product() { ProductID = 2, ProductName = "Apple MacBook Pro", ProductDescription = "Powerful laptop for work and entertainment", ProductPrice = 1499.99m },
            new Product() { ProductID = 3, ProductName = "Jabra Headphones", ProductDescription = "Premium noise-canceling headphones for immersive audio experience", ProductPrice = 299.99m },
            new Product() { ProductID = 4, ProductName = "Apple Smartwatch", ProductDescription = "Fitness tracker with smart features for active lifestyle", ProductPrice = 199.99m },
            new Product() { ProductID = 5, ProductName = "JBL Wireless Speaker", ProductDescription = "High-fidelity wireless speaker for home entertainment", ProductPrice = 499.99m }
        };

        public List<Inventory> InventoryCollection = new List<Inventory>()
        {
            new Inventory() { InventoryID = 1, ProductID = 1, StockQuantity = 50 },
            new Inventory() { InventoryID = 2, ProductID = 2, StockQuantity = 30 },
            new Inventory() { InventoryID = 3, ProductID = 3, StockQuantity = 20 },
            new Inventory() { InventoryID = 4, ProductID = 4, StockQuantity = 40 },
            new Inventory() { InventoryID = 5, ProductID = 5, StockQuantity = 25 }
        };

        public int AddProductID()
        {
            return productIDCounter++;
        }

        // Add method to generate unique InventoryID
        public int AddInventoryID()
        {
            return inventoryIDCounter++;
        }

        public Database()
        {

        }
    }
}
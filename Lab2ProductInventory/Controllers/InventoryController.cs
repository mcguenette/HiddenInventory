using Lab2ProductInventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Lab2ProductInventory.Controllers
{
    public class InventoryController : Controller
    {
        private readonly Database database;

        public InventoryController()
        {
            database = DatabaseBusinessLogic.GetDatabaseInstance();
        }
        /// <summary>
        /// GET: Inventory
        /// Combine the Product and Inventory data
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var productsWithInventory = database.ProductsCollection
                .Join(database.InventoryCollection,
                    product => product.ProductID,
                    inventory => inventory.ProductID,
                    (product, inventory) => new ProductInventoryBusinessLogic { Product = product, Inventory = inventory }) // Looked into "Tuple", but got nervous to try it out. :)
                .ToList();

            return View(productsWithInventory);
        }

        /// <summary>
        /// GET: Create Product VIEW
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateProduct()
        {
            return View();
        }
        /// <summary>
        /// POST: Create Product through a button and show form
        /// </summary>
        /// <param name="product"></param>
        /// <param name="inventory"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous] // [ValidateAntiForgeryToken] wasn't working so googled it
                         // and I know this isn't the right way BUT it got Create and Delete to temp work.
                         // will look into this improvement at a later time.
        public ActionResult CreateProduct(Product product, Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                // Generate a unique ProductID
                product.ProductID = database.ProductsCollection.Count + 1;

                // Add product to Collection
                database.ProductsCollection.Add(product);

                // Connect inventory product id with product id
                inventory.ProductID = product.ProductID;

                // Add inventory to the InventoryCollection
                database.InventoryCollection.Add(inventory);

                // Redirect back to list of products
                return RedirectToAction("Index");
            }
            return View(product);
        }
        /// <summary>
        /// GET: Delete Product functionality button on index page/view
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public ActionResult DeleteProduct(int productID)
        {
            // Find the product through prod id and inventory to delete
            var productToRemove = database.ProductsCollection.FirstOrDefault(p => p.ProductID == productID);
            var inventoryToRemove = database.InventoryCollection.FirstOrDefault(i => i.ProductID == productID);

            // Delete the product and inventory
            if (productToRemove != null && inventoryToRemove != null)
            {
                database.ProductsCollection.Remove(productToRemove);
                database.InventoryCollection.Remove(inventoryToRemove);
            }
            // Redirect back to list of products
            return RedirectToAction(nameof(Index));
        }
    }

}
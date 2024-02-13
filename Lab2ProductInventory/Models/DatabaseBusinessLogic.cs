using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2ProductInventory.Models
{
    public static class DatabaseBusinessLogic
    {
        private static Database databaseInstance;

        public static Database GetDatabaseInstance()
        {
            if (databaseInstance == null)
            {
                databaseInstance = new Database();
            }
            return databaseInstance;
        }
    }
}
using System;

namespace kebab_house
{
    public class WarehouseManager
    {
        private Warehouse warehouse;

        public WarehouseManager(Warehouse warehouse)
        {
            this.warehouse = warehouse;
        }

        public void RestockIngredient(string name, int quantity)
        {
            warehouse.AddIngredient(name, quantity);
            Console.WriteLine($"{quantity} units of {name} added to the warehouse by Warehouse Manager.");
        }
    }
}

using System;

namespace KebabHouse
{
    public class WarehouseManager
    {
        private readonly Warehouse _warehouse;

        public WarehouseManager(Warehouse warehouse)
        {
            _warehouse = warehouse;
        }

        public void RestockIngredient(string name, int quantity)
        {
            _warehouse.AddIngredient(name, quantity);
            Console.WriteLine($"{quantity} units of {name} added to the warehouse by Warehouse Manager.");
        }
    }
}

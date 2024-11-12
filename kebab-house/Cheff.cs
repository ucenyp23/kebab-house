using System;

namespace kebab_house
{
    public class Cheff
    {
        private Warehouse warehouse;
        private WarehouseManager warehouseManager;

        public Cheff(Warehouse warehouse, WarehouseManager warehouseManager)
        {
            this.warehouse = warehouse;
            this.warehouseManager = warehouseManager;
        }

        public void CreateKebab(Kebab kebab)
        {
            if (kebab.CanBeMade(warehouse))
            {
                kebab.Make(warehouse);
                Console.WriteLine($"Cheff created a {kebab.GetName()}.");
            }
            else
            {
                Console.WriteLine($"Not enough ingredients to make {kebab.GetName()}. Asking WarehouseManager to resupply.");
                RequestResupply(kebab);
                if (kebab.CanBeMade(warehouse))
                {
                    kebab.Make(warehouse);
                    Console.WriteLine($"Cheff created a {kebab.GetName()} after resupply.");
                }
                else
                {
                    Console.WriteLine($"Even after resupply, there are not enough ingredients to make {kebab.GetName()}.");
                }
            }
        }

        private void RequestResupply(Kebab kebab)
        {
            foreach (var ingredient in kebab.GetIngredients())
            {
                int neededAmount = ingredient.Value;
                warehouseManager.RestockIngredient(ingredient.Key, neededAmount);
            }
        }
    }
}

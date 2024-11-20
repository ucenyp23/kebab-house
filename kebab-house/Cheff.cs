using System;

namespace KebabHouse
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
                Console.WriteLine($"Cheff created a {kebab.GetName()} Kebab.");
            }
            else
            {
                Console.WriteLine($"Not enough ingredients to make {kebab.GetName()} Kebab. Asking WarehouseManager to resupply.");
                RequestResupply(kebab);
                if (kebab.CanBeMade(warehouse))
                {
                    kebab.Make(warehouse);
                    Console.WriteLine($"Cheff created a {kebab.GetName()} Kebab after resupply.");
                }
                else
                {
                    Console.WriteLine($"Even after resupply, there are not enough ingredients to make {kebab.GetName()} Kebab.");
                }
            }
        }

        private void RequestResupply(Kebab kebab)
        {
            Dictionary<string, int> availableIngredients = warehouse.GetIngredients();
            foreach (var ingredient in kebab.GetIngredients())
            {
                if (!availableIngredients.ContainsKey(ingredient.Key) || availableIngredients[ingredient.Key] < ingredient.Value)
                {
                    int neededAmount = ingredient.Value - (availableIngredients.ContainsKey(ingredient.Key) ? availableIngredients[ingredient.Key] : 0);
                    warehouseManager.RestockIngredient(ingredient.Key, neededAmount);
                }
            }
        }
    }
}

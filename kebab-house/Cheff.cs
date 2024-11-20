using System;

namespace KebabHouse
{
    public class Chef
    {
        private readonly Warehouse _warehouse;
        private readonly WarehouseManager _warehouseManager;

        public Chef(Warehouse warehouse, WarehouseManager warehouseManager)
        {
            _warehouse = warehouse;
            _warehouseManager = warehouseManager;
        }

        public void CreateKebab(Kebab kebab)
        {
            if (kebab.CanBeMade(_warehouse))
            {
                kebab.Make(_warehouse);
                Console.WriteLine($"Chef created a {kebab.Name} Kebab.");
            }
            else
            {
                Console.WriteLine($"Not enough ingredients to make {kebab.Name} Kebab. Asking WarehouseManager to resupply.");
                RequestResupply(kebab);
                if (kebab.CanBeMade(_warehouse))
                {
                    kebab.Make(_warehouse);
                    Console.WriteLine($"Chef created a {kebab.Name} Kebab after resupply.");
                }
                else
                {
                    Console.WriteLine($"Even after resupply, there are not enough ingredients to make {kebab.Name} Kebab.");
                }
            }
        }

        private void RequestResupply(Kebab kebab)
        {
            var availableIngredients = _warehouse.Ingredients;
            foreach (var ingredient in kebab.Ingredients)
            {
                if (!availableIngredients.ContainsKey(ingredient.Key) || availableIngredients[ingredient.Key] < ingredient.Value)
                {
                    var neededAmount = ingredient.Value - (availableIngredients.ContainsKey(ingredient.Key) ? availableIngredients[ingredient.Key] : 0);
                    _warehouseManager.RestockIngredient(ingredient.Key, neededAmount);
                }
            }
        }
    }
}

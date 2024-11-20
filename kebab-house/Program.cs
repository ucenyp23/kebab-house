using System;
using System.Collections.Generic;

namespace kebab_house
{
    class Program
    {
        static void Main(string[] args)
        {
            Warehouse warehouse = new Warehouse();
            WarehouseManager warehouseManager = new WarehouseManager(warehouse);
            Cheff cheff = new Cheff(warehouse, warehouseManager);

            warehouse.AddIngredient("Meat", 500);
            warehouse.AddIngredient("Tomato", 300);
            warehouse.AddIngredient("Lettuce", 200);
            warehouse.AddIngredient("Ketchup", 250);
            warehouse.AddIngredient("Bun", 150);
            warehouse.AddIngredient("Onion", 100);
            warehouse.AddIngredient("Cheese", 150);
            warehouse.AddIngredient("Cucumber", 100);
            warehouse.AddIngredient("Yogurt", 80);
            warehouse.AddIngredient("Chili", 50);

            List<Kebab> kebabs = new List<Kebab>
            {
                new Kebab("Classic Kebab", new Dictionary<string, int> { { "Meat", 10 }, { "Tomato", 5 }, { "Lettuce", 3 } }),
                new Kebab("Special Kebab", new Dictionary<string, int> { { "Meat", 15 }, { "Tomato", 5 }, { "Lettuce", 5 }, { "Ketchup", 10 }, { "Bun", 1 } }),
                new Kebab("Cheese Kebab", new Dictionary<string, int> { { "Meat", 10 }, { "Cheese", 7 }, { "Lettuce", 3 } }),
                new Kebab("Veggie Kebab", new Dictionary<string, int> { { "Tomato", 5 }, { "Lettuce", 5 }, { "Cucumber", 5 }, { "Onion", 3 } }),
                new Kebab("Spicy Kebab", new Dictionary<string, int> { { "Meat", 10 }, { "Chili", 5 }, { "Tomato", 3 }, { "Lettuce", 2 } }),
                new Kebab("Yogurt Kebab", new Dictionary<string, int> { { "Meat", 10 }, { "Yogurt", 5 }, { "Tomato", 3 }, { "Lettuce", 2 } }),
                new Kebab("Double Meat Kebab", new Dictionary<string, int> { { "Meat", 20 }, { "Tomato", 5 }, { "Lettuce", 3 } }),
                new Kebab("Onion Lover Kebab", new Dictionary<string, int> { { "Meat", 10 }, { "Onion", 7 }, { "Tomato", 3 }, { "Lettuce", 2 } }),
                new Kebab("Cucumber Delight Kebab", new Dictionary<string, int> { { "Meat", 10 }, { "Cucumber", 7 }, { "Tomato", 3 }, { "Lettuce", 2 } }),
                new Kebab("Ketchup Kebab", new Dictionary<string, int> { { "Meat", 10 }, { "Ketchup", 10 }, { "Tomato", 3 }, { "Lettuce", 2 } })
            };

            while (true)
            {
                Console.WriteLine("\nKebab Menu:");
                for (int i = 0; i < kebabs.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {kebabs[i].GetName()} ({string.Join(", ", kebabs[i].GetIngredients().Select(x => $"{x.Key}: {x.Value}"))}) - {kebabs[i].GetPrice():F2} EUR");
                }
                Console.WriteLine("11. Display Warehouse");
                Console.WriteLine("12. Create Custom Kebab");
                Console.WriteLine("13. Exit");
                Console.Write("Choose an option: ");
                int option;
                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid input, please enter a number.");
                    continue;
                }


                if (option >= 1 && option <= 10)
                {
                    cheff.CreateKebab(kebabs[option - 1]);
                }
                else if (option == 11)
                {
                    warehouse.DisplayIngredients();
                }
                else if (option == 12)
                {
                    CreateCustomKebab(warehouse, cheff);
                }
                else if (option == 13)
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid option, please try again.");
                }
            }
        }

        static void CreateCustomKebab(Warehouse warehouse, Cheff cheff)
        {
            Console.Write("Enter kebab name: ");
            string? name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Kebab name cannot be empty.");
                return;
            }

            Dictionary<string, int> ingredients = new Dictionary<string, int>();
            while (true)
            {
                Console.Write("Enter ingredient (or 'done' to finish): ");
                string? ingredient = Console.ReadLine();
                if (string.IsNullOrEmpty(ingredient) || ingredient.ToLower() == "done")
                {
                    break;
                }

                Console.Write("Enter quantity: ");
                int quantity;
                if (!int.TryParse(Console.ReadLine(), out quantity))
                {
                    Console.WriteLine("Invalid input, please enter a number.");
                    continue;
                }
                ingredients[ingredient] = quantity;
            }

            Kebab customKebab = new Kebab(name, ingredients);
            cheff.CreateKebab(customKebab);
        }
    }
}

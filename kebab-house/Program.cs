using System;
using System.Collections.Generic;

namespace KebabHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            Warehouse warehouse = new Warehouse();
            WarehouseManager warehouseManager = new WarehouseManager(warehouse);
            Cheff cheff = new Cheff(warehouse, warehouseManager);

            warehouse.AddIngredient("Pita Bread", 100);
            warehouse.AddIngredient("Lamb", 1000);
            warehouse.AddIngredient("Tomato", 500);
            warehouse.AddIngredient("Lettuce", 300);
            warehouse.AddIngredient("Ketchup", 150);
            warehouse.AddIngredient("Onion", 100);
            warehouse.AddIngredient("Cheese", 150);
            warehouse.AddIngredient("Cucumber", 100);
            warehouse.AddIngredient("Yogurt", 80);
            warehouse.AddIngredient("Chili", 50);

            List<Kebab> kebabs = new List<Kebab>
            {
                new Kebab("Classic", new Dictionary<string, int> { { "Lamb", 200 }, { "Tomato", 1 }, { "Lettuce", 50 }, { "Pita Bread", 1 } }),
                new Kebab("Special", new Dictionary<string, int> { { "Lamb", 250 }, { "Tomato", 1 }, { "Lettuce", 50 }, { "Ketchup", 25 }, { "Pita Bread", 1 } }),
                new Kebab("Cheese", new Dictionary<string, int> { { "Lamb", 200 }, { "Cheese", 50 }, { "Lettuce", 50 }, { "Pita Bread", 1 } }),
                new Kebab("Veggie", new Dictionary<string, int> { { "Tomato", 1 }, { "Lettuce", 50 }, { "Cucumber", 1 }, { "Onion", 25 }, { "Pita Bread", 1 } }),
                new Kebab("Spicy", new Dictionary<string, int> { { "Lamb", 200 }, { "Chili", 5 }, { "Tomato", 1 }, { "Lettuce", 50 }, { "Pita Bread", 1 } }),
                new Kebab("Yogurt", new Dictionary<string, int> { { "Lamb", 200 }, { "Yogurt", 3 }, { "Tomato", 1 }, { "Lettuce", 50 }, { "Pita Bread", 1 } })
            };

            while (true)
            {
                Console.WriteLine("\nKebab Menu:");
                for (int i = 0; i < kebabs.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {kebabs[i].GetName()} Kebab ({string.Join(", ", kebabs[i].GetIngredients().Select(x => $"{x.Key}: {x.Value}"))}) - {kebabs[i].GetPrice():F2} EUR");
                }
                Console.WriteLine("7. Display Warehouse");
                Console.WriteLine("8. Create Custom Kebab");
                Console.WriteLine("9. Exit");
                Console.Write("Choose an option: ");
                int option;
                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid input, please enter a number.");
                    continue;
                }

                if (option >= 1 && option <= 6)
                {
                    cheff.CreateKebab(kebabs[option - 1]);
                }
                else if (option == 7)
                {
                    warehouse.DisplayIngredients();
                }
                else if (option == 8)
                {
                    CreateCustomKebab(warehouse, cheff);
                }
                else if (option == 9)
                {
                    Console.Clear();
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
            double price = customKebab.GetPrice();
            Console.WriteLine($"'{name}' Kebab was created with price: {price:F2} EUR");
            cheff.CreateKebab(customKebab);
        }
    }
}

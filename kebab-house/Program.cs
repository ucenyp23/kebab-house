using System;
using System.Collections.Generic;

namespace kebab_house
{
    class Program
    {
        static void Main(string[] args)
        {
            Warehouse warehouse = new Warehouse();

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
                    Console.WriteLine($"{i + 1}. {kebabs[i].Name}");
                }
                Console.WriteLine("11. Display Warehouse");
                Console.WriteLine("12. Exit");
                Console.Write("Choose an option: ");
                int option = int.Parse(Console.ReadLine());

                if (option >= 1 && option <= 10)
                {
                    kebabs[option - 1].Make(warehouse.GetIngredients(), 1);
                }
                else if (option == 11)
                {
                    warehouse.DisplayIngredients();
                }
                else if (option == 12)
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid option, please try again.");
                }
            }
        }
    }

    class Warehouse
    {
        private Dictionary<string, int> ingredients = new Dictionary<string, int>();

        public void AddIngredient(string name, int quantity)
        {
            if (ingredients.ContainsKey(name))
            {
                ingredients[name] += quantity;
            }
            else
            {
                ingredients[name] = quantity;
            }
        }

        public void DisplayIngredients()
        {
            Console.WriteLine("\nCurrent ingredients:");
            foreach (var ingredient in ingredients)
            {
                Console.WriteLine($"{ingredient.Key}: {ingredient.Value}");
            }
        }

        public Dictionary<string, int> GetIngredients()
        {
            return ingredients;
        }
    }

    class Kebab
    {
        public string Name { get; set; }
        private Dictionary<string, int> Ingredients { get; set; }

        public Kebab(string name, Dictionary<string, int> ingredients)
        {
            Name = name;
            Ingredients = ingredients;
        }

        public void Make(Dictionary<string, int> warehouseIngredients, int quantity)
        {
            bool canMake = true;

            foreach (var ingredient in Ingredients)
            {
                if (!warehouseIngredients.ContainsKey(ingredient.Key) || warehouseIngredients[ingredient.Key] < ingredient.Value * quantity)
                {
                    canMake = false;
                    break;
                }
            }

            if (canMake)
            {
                foreach (var ingredient in Ingredients)
                {
                    warehouseIngredients[ingredient.Key] -= ingredient.Value * quantity;
                }
                Console.WriteLine($"\n{quantity} {Name}(s) made successfully!");
            }
            else
            {
                Console.WriteLine($"\nNot enough ingredients to make {quantity} {Name}(s).");
            }
        }
    }
}

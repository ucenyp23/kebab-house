using System;
using System.Collections.Generic;

namespace KebabHouse
{
    public class Warehouse
    {
        public Dictionary<string, int> Ingredients { get; private set; }

        public Warehouse()
        {
            Ingredients = new Dictionary<string, int>();
        }

        public void AddIngredient(string name, int quantity)
        {
            if (Ingredients.ContainsKey(name))
            {
                Ingredients[name] += quantity;
            }
            else
            {
                Ingredients[name] = quantity;
            }
        }

        public void DisplayIngredients()
        {
            Console.WriteLine("Current ingredients in the warehouse:");
            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine($"{ingredient.Key}: {ingredient.Value}");
            }
        }
    }
}

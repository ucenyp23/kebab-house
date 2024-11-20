using System;
using System.Collections.Generic;

namespace KebabHouse
{
    public class Kebab
    {
        public string Name { get; }
        public Dictionary<string, int> Ingredients { get; }
        private double BasePrice { get; }
        private double TaxRate { get; }

        public Kebab(string name, Dictionary<string, int> ingredients)
        {
            Name = name;
            Ingredients = ingredients;
            TaxRate = 0.15;
            BasePrice = CalculatePrice();
        }

        public bool CanBeMade(Warehouse warehouse)
        {
            var ingredientDict = warehouse.Ingredients;
            foreach (var ingredient in Ingredients)
            {
                if (!ingredientDict.ContainsKey(ingredient.Key) || ingredientDict[ingredient.Key] < ingredient.Value)
                {
                    return false;
                }
            }
            return true;
        }

        public void Make(Warehouse warehouse)
        {
            var ingredientDict = warehouse.Ingredients;
            foreach (var ingredient in Ingredients)
            {
                ingredientDict[ingredient.Key] -= ingredient.Value;
            }
        }

        private double CalculatePrice()
        {
            var ingredientPrices = new Dictionary<string, double> {
                { "Lamb", 2.0 },
                { "Chicken", 1.8 },
                { "Tomato", 0.2 },
                { "Lettuce", 0.1 },
                { "Ketchup", 0.3 },
                { "Pita Bread", 0.5 },
                { "Onion", 0.15 },
                { "Cheese", 0.4 },
                { "Cucumber", 0.25 },
                { "Yogurt", 0.35 },
                { "Chili", 0.2 }
            };
            var totalPrice = 0.0;
            foreach (var ingredient in Ingredients)
            {
                totalPrice += ingredient.Value * ingredientPrices[ingredient.Key];
            }
            return totalPrice;
        }

        public double Price => BasePrice * (1 + TaxRate);
    }
}

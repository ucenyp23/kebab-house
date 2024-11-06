using System;

public class Kebab
{
    private string Name;
    private Dictionary<string, int> Ingredients;

    public Kebab(string name, Dictionary<string, int> ingredients)
    {
        Name = name;
        Ingredients = ingredients;
    }

    private bool CanBeMade(Dictionary<string, Ingredient> warehouse)
    {
        foreach (var ingredient in Ingredients)
        {
            if (!warehouse.ContainsKey(ingredient.Key) || warehouse[ingredient.Key].GetQuantity() < ingredient.Value)
            {
                return false;
            }
        }
        return true;
    }

    public void Make(Dictionary<string, Ingredient> warehouse)
    {
        if (CanBeMade(warehouse))
        {
            foreach (var ingredient in Ingredients)
            {
                warehouse[ingredient.Key].ReduceQuantity(ingredient.Value);
            }
            Console.WriteLine($"Kebab {Name} was made.");
        }
        else
        {
            Console.WriteLine($"Not enough ingredients to make {Name}.");
        }
    }
}

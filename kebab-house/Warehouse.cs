using System;

public class Warehouse
{
    private Dictionary<string, Ingredient> Ingredients;

    public Warehouse()
    {
        Ingredients = new Dictionary<string, Ingredient>();
    }

    public void AddIngredient(string name, int quantity)
    {
        if (Ingredients.ContainsKey(name))
        {
            Ingredients[name].AddQuantity(quantity);
        }
        else
        {
            Ingredients[name] = new Ingredient(name, quantity);
        }
    }

    public void DisplayIngredients()
    {
        Console.WriteLine("Current ingredients in the warehouse:");
        foreach (var ingredient in Ingredients)
        {
            Console.WriteLine($"{ingredient.Value.GetName()}: {ingredient.Value.GetQuantity()}");
        }
    }

    public Dictionary<string, Ingredient> GetIngredients()
    {
        return Ingredients;
    }
}

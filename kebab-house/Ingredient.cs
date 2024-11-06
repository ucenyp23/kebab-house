using System;

public class Ingredient
{
    private string Name;
    private int Quantity;

    public Ingredient(string name, int quantity)
    {
        Name = name;
        Quantity = quantity;
    }

    public void AddQuantity(int amount)
    {
         Quantity += amount;
    }

    public void ReduceQuantity(int amount)
    {
         Quantity -= amount;
    }

    public string GetName()
    {
        return Name;
    }

    public int GetQuantity()
    {
        return Quantity;
    }
}

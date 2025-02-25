using UnityEngine;

public struct Ingredient
{
    public enum Type
    {
        Tomato,
        Pepper,
        Onion,
        Cauliflower,
        Eggplant,
    }
    public Type ingredientType;
    public int amount;
    public double quality;
    
    public Ingredient(Type type, int amount, double quality)
    {
        this.ingredientType = type;
        this.amount = amount;
        this.quality = quality;
    }
}

using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public enum IngredientType
    {
        Tomato,
        Pepper,
        Onion,
        Cauliflower,
        Eggplant,
    }
    public IngredientType ingredientType;
    public int amount;
    public double quality;

}

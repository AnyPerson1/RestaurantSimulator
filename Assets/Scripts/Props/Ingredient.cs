using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public enum IngredientType
    {
        Pepper,
        Tomato,
        Onion,
        Cauliflower,
        Eggplant,
    }
    [SerializeField] public IngredientType ingredientType;
    [SerializeField] public float quality;
}

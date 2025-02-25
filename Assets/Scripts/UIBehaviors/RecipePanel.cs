using System.Collections.Generic;
using UnityEngine;

public class RecipePanel : MonoBehaviour
{
    [SerializeField] private GameObject ingredientSlotParent;
    [SerializeField] private GameObject recipeSlotParent;

    [SerializeField] private GameObject ingredientSlotPrefab;
    [SerializeField] private GameObject recipeSlotPrefab;

    public Dictionary<GameObject, Ingredient> ingredientSlots;
    public Dictionary<GameObject, Ingredient> recipeSlots;

    private void Start()
    {
        //storage ye eri�ip i�indeki ingredientleri al�p ekleme;
    }

    public void AddIngredient(Ingredient.Type ingredient, int amount, double quality)
    {
        GameObject slot = Instantiate(ingredientSlotPrefab);
        slot.transform.SetParent(ingredientSlotParent.transform);
        Ingredient ingredientClass = slot.GetComponent<Ingredient>();
        ingredientClass.ingredientType = ingredient;
        ingredientClass.amount = amount;
        ingredientClass.quality = quality;
        ingredientSlots.Add(slot , ingredientClass);
    }
}

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
        //storage ye eriþip içindeki ingredientleri alýp ekleme;
    }

    public void AddIngredient(Ingredient ingredient)
    {
        GameObject slot = Instantiate(ingredientSlotPrefab);
        slot.transform.SetParent(ingredientSlotParent.transform);
        ingredientSlots.Add(slot,ingredient);
    }
}

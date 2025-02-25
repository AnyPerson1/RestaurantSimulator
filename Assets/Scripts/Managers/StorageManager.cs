using System;
using System.Collections.Generic;
using UnityEngine;

public class StorageManager : MonoBehaviour
{
    [SerializeField] public List<Ingredient> storedIngredients;

    private void Awake()
    {
        storedIngredients = new List<Ingredient>();
        // Ingredient example = new Ingredient();
        // example.ingredientType = Ingredient.Type.Tomato;
        // example.amount = 50;
        // storedIngredients.Add(example);
    }

    public void ReloadGlobalStorage()
    {
        
    }
}

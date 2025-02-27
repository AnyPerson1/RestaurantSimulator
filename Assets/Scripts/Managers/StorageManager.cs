using System;
using System.Collections.Generic;
using UnityEngine;

public class StorageManager : MonoBehaviour
{
    [SerializeField] public List<Ingredient> storedIngredients;
    [SerializeField] public List<Storage> storagesInScene;
    public bool storageReady = false;

    private void Awake()
    {
        storageReady = false;
        storagesInScene = new List<Storage>();
        storedIngredients = new List<Ingredient>();
        storageReady = true;
    }


    // Expensive method ahead
    // Alternative: Add storage components to a public list (e.g., storagesInScene) dynamically 
    // in the Start method using the Storage script.
    // After that, compare the count of scene objects with the count of the list.

    //Use this method if its seriously necessary.
    public void ReloadGlobalStorage()
    {
        storagesInScene.Clear();
        GameObject[] storageObjects = GameObject.FindGameObjectsWithTag("LocalStorage");
        foreach (GameObject storageObject in storageObjects)
        {
            storagesInScene.Add(storageObject.GetComponent<Storage>());
        }
    }
    public void AddIngredients(List<Ingredient> ingredients)
    {
        foreach (var ingredient in ingredients)
        {
            bool found = false;

            for (int i = 0; i < storedIngredients.Count; i++)
            {
                if (storedIngredients[i].ingredientType == ingredient.ingredientType)
                {
                    storedIngredients[i] = new Ingredient(
                        storedIngredients[i].ingredientType,
                        storedIngredients[i].amount + ingredient.amount,
                        storedIngredients[i].quality
                    );
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                storedIngredients.Add(ingredient);
            }
        }
    }

}

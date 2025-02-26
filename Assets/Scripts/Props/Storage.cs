using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Storage : MonoBehaviour
{
    [SerializeField] public int maxStorage = 100;
    [SerializeField] public int currentStorage = 0;
    [SerializeField] private StorageManager storageManager;
    [SerializeField] public List<Ingredient> ingredients = new List<Ingredient>();

    private void Start()
    {
        storageManager = GameObject.FindGameObjectWithTag("GlobalStorage").GetComponent<StorageManager>();
        storageManager.storageReady = false;
        if (!storageManager.storagesInScene.Contains(this))
            storageManager.storagesInScene.Add(this);
        else
            Debug.Log("Some 'Storage' class tried to add itself to global storage list more than one time");
        AddRandomStorage();
        storageManager.AddIngredients(ingredients);
        storageManager.storageReady = true;
    }

    private void AddRandomStorage()
    {
        AddIngredient(new Ingredient(Ingredient.Type.Onion,UnityEngine.Random.Range(5,150),0.5D));
        AddIngredient(new Ingredient(Ingredient.Type.Tomato,UnityEngine.Random.Range(5, 150) , 0.5D));
        AddIngredient(new Ingredient(Ingredient.Type.Pepper,UnityEngine.Random.Range(5, 150), 0.5D));
        AddIngredient(new Ingredient(Ingredient.Type.Eggplant,UnityEngine.Random.Range(5, 150), 0.5D));
        AddIngredient(new Ingredient(Ingredient.Type.Cauliflower,UnityEngine.Random.Range(5, 150) ,0.5D));
    }

    private void AddIngredient(Ingredient ingredient)
    {
        for (int i = 0; i < ingredients.Count; i++)
        {
            if (ingredients[i].ingredientType == ingredient.ingredientType)
            {
                ingredients[i] = new Ingredient(
                    ingredients[i].ingredientType,
                    ingredients[i].amount + ingredient.amount,
                    ingredients[i].quality
                );
                return;
            }
        }

        ingredients.Add(ingredient);
    }
    private void RemoveIngredient(Ingredient ingredient)
    {
        for (int i = 0; i < ingredients.Count; i++)
        {
            if (ingredients[i].ingredientType == ingredient.ingredientType)
            {
                int newAmount = ingredients[i].amount - ingredient.amount;

                if (newAmount > 0)
                {
                    ingredients[i] = new Ingredient(
                        ingredients[i].ingredientType,
                        newAmount,
                        ingredients[i].quality
                    );
                }
                else if (newAmount == 0)
                {
                    ingredients.RemoveAt(i);
                }
                else
                {
                    Debug.LogError("Removing amount from storage was bigger than current stored ingredient amount. So process canceled.");
                    return;
                    
                }
                return;
            }
        }
    }
}

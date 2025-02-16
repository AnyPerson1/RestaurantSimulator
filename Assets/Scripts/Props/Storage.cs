using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Storage : MonoBehaviour
{
    [SerializeField] public int maxStorage = 100;
    [SerializeField] public int currentStorage = 0;
    [SerializeField] public Dictionary<Ingredient.IngredientType,int> storage = new Dictionary<Ingredient.IngredientType, int>();

    // returns if there is a leftover from fill
    public int AddStorage(Ingredient.IngredientType ingredientType, int amount)
    {
        int leftover = 0;
        if (storage.Keys.Contains(ingredientType))
        {
            if (currentStorage+amount <= maxStorage)
            {
                storage[ingredientType] += amount;
                currentStorage += amount;
            }
            else
            {
                leftover = maxStorage - currentStorage;
                currentStorage = maxStorage;
            }
        }
        else
        {
            if (currentStorage + amount <= maxStorage)
            {
                storage.Add(ingredientType, amount);
                currentStorage += amount;
            }
            else
            {
                leftover = maxStorage - currentStorage;
                currentStorage = maxStorage;
            }
        }
        return leftover;
    }
}

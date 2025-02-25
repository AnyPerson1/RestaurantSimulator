using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Storage : MonoBehaviour
{
    [SerializeField] public int maxStorage = 100;
    [SerializeField] public int currentStorage = 0;
    [SerializeField] public Dictionary<Ingredient.Type,int> storage = new Dictionary<Ingredient.Type, int>();
    [SerializeField] public List<Ingredient> ingredients = new List<Ingredient>();


    // returns if there is a leftover from fill
    public int AddStorage(Ingredient.Type Type, int amount)
    {
        int leftover = 0;
        if (currentStorage == maxStorage)
            return amount;
        if (storage.Keys.Contains(Type))
        {
            if (currentStorage+amount <= maxStorage)
            {
                storage[Type] += amount;
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
                storage.Add(Type, amount);
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

    public int RemoveStorage(Ingredient.Type type, int amount)
    {
        int exceed = 0;
        if (storage.Keys.Contains(type))
        {
            if (amount >= storage[type])
            {
                exceed = storage[type] - amount;
                storage.Remove(type);
            }
            else
            {
                storage[type] -= amount;
            }
        }
        else
        {
            Debug.LogError("Removing storage from a storage is completed with an error: There is no any storage with "+type+" key.");
            return amount;
        }
        return exceed;
    }
}

using System.Collections.Generic;
using UnityEngine;

public class Cooker : MonoBehaviour, IInteractable
{
    [SerializeField] public int capacity;
    [SerializeField] private string currentRecipe;

    public void Interact()
    {
        
    }
}

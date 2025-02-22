using System;
using UnityEngine;

public class Prop : MonoBehaviour
{
    public enum PropType{
        Counter,
        Cooker,
        Table,
        Furnace,
        Storage
    }
    
    [SerializeField] public int level;
    [SerializeField] public IInteractable interactable;
    [SerializeField] public PropType propType;

    private void Awake()
    {
        interactable = GetComponent<IInteractable>();
    }

    private void Start()
    {
        interactable?.Interact();
    }
}

using UnityEngine;

public class Prop : MonoBehaviour, IInteractable
{
    public enum PropType{
        Counter,
        Cooker,
        Table,
        Furnace,
        Storage
    }
    private InteractManager _interactManager;
    private void Awake()
    {
        _interactManager = FindObjectOfType<InteractManager>();
    }
    
    [SerializeField] public PropType propType;

    public void Interact()
    {
        _interactManager.Interact(propType, gameObject);
    }
}

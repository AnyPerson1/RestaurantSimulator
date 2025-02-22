using System;
using UnityEngine;

public class InteractManager : MonoBehaviour
{
    public void Interact(Prop.PropType propType, GameObject sender)
    {
        switch (propType)
        {
            case Prop.PropType.Cooker:
                break;
            default:
                break;
        }
    }
    
    [SerializeField] private LayerMask interactLayer;
    [SerializeField] public bool canInteract = true;
    private void Update()
    {
        if (canInteract && Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, interactLayer))
            {
                Debug.Log("Interaction triggered : "+hit.collider.gameObject.name);
            }
        }
    }
}
public interface IInteractable
{
    public void Interact();
}

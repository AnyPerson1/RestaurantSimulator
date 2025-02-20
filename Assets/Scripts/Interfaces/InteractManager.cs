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
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, interactLayer))
            {
                Debug.Log("Interaction triggered : "+hit.collider.gameObject.name);
                hit.collider.gameObject.GetComponent<Prop>().Interact();
            }
        }
    }
}
interface IInteractable
{
    public void Interact();
}

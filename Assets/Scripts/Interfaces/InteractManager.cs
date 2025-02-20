using System;
using UnityEngine;

public class InteractManager : MonoBehaviour
{
    [SerializeField] private LayerMask interactLayer;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, interactLayer))
            {
                
            }
        }
    }
}
interface IInteractable
{
    public void Interact();
}

using System.Collections.Generic;
using UnityEngine;

public class Cooker : MonoBehaviour, IInteractable
{
    private const float INDICATOR_INTERPOLATION_MAX_TOLERANCE = 0.01f;
    
    [SerializeField] public int capacity;
    [SerializeField] private string currentRecipe;
    
    [Header("Indicator")]
    [SerializeField] private RectTransform indicator;
    [SerializeField] private RectTransform startpos;
    [SerializeField] private RectTransform endpos;
    public void Interact()
    {
        
    }

    public void IndicatorStart()
    {
        while (indicator.position.y - endpos.position.y > INDICATOR_INTERPOLATION_MAX_TOLERANCE)
        {
            
        }
    }
}

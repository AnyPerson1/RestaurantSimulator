using System;
using System.Collections;
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
    [SerializeField] private float interpolationSpeed;

    private void Start()
    {
        IndicatorStart();
    }

    public void Interact()
    {
        
    }

    private IEnumerator IndicatorStart()
    {
        while (Vector3.Distance(indicator.position,endpos.position) > INDICATOR_INTERPOLATION_MAX_TOLERANCE)
        {
            indicator.position = Vector3.Lerp(indicator.position, endpos.position, Time.deltaTime * interpolationSpeed);
        }

        yield return null;
    }
}

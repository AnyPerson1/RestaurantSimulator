using System;
using System.Collections;
using UnityEngine;

public class Cooker : MonoBehaviour, IInteractable
{
    private const float INDICATOR_INTERPOLATION_MAX_TOLERANCE = 0.05f;
    
    [SerializeField] public InteractManager interactManager;
    
    [SerializeField] public int capacity;
    [SerializeField] private string currentRecipe;
    
    [Header("Local Canvas")]
    [SerializeField] private GameObject canvas;
    
    [Header("Indicator Settings")]
    [SerializeField] private RectTransform indicator; 
    [SerializeField] private RectTransform startPos;  
    [SerializeField] private RectTransform endPos;   
    [SerializeField] private float speedMultiplier;
    [SerializeField] private float speedMultiplierMultiplier;

    [Header("Objects")]
    [SerializeField] private GameObject pot;   
    [SerializeField] private GameObject particles;  

    private bool _indicatorState = false;
    private bool _stopIndicator = false;


    private void Awake()
    {
        interactManager = FindFirstObjectByType<InteractManager>();
    }
    
    private void Update()
    {
        if (_indicatorState && Input.GetMouseButtonDown(0))
        {
            _stopIndicator = true;
        }
    }
    public void Interact()
    {
       Debug.Log("Interact");
    }
    private IEnumerator IndicatorStart()
    {
        yield return new WaitForSeconds(1f);
        _indicatorState = true;
        pot.SetActive(true);
        particles.SetActive(true);
        interactManager.canInteract = false;
        while (Vector3.Distance(indicator.position, endPos.position) > INDICATOR_INTERPOLATION_MAX_TOLERANCE && !_stopIndicator && indicator.position.y < endPos.position.y)
        {
            speedMultiplier *= speedMultiplierMultiplier;
            indicator.position = new Vector3(indicator.position.x, indicator.position.y * speedMultiplier, indicator.position.z);
            yield return null;
        }
        
        if (!_stopIndicator)
        {
            Debug.LogError("Over Cooked");
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(indicator.position, new Vector2(-1, 0), Mathf.Infinity, LayerMask.GetMask("UI"));
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.tag);
            }
        }
        interactManager.canInteract = true;
        particles.SetActive(false);
        _stopIndicator = false;
        _indicatorState = false;
    }
}

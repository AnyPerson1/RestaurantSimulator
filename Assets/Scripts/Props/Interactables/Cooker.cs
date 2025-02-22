using System.Collections;
using UnityEngine;

public class Cooker : MonoBehaviour, IInteractable
{
    private const float INDICATOR_INTERPOLATION_MAX_TOLERANCE = 0.05f;
    
    [SerializeField] public int capacity;
    [SerializeField] private string currentRecipe;
    
    [Header("Indicator Settings")]
    [SerializeField] private RectTransform indicator; 
    [SerializeField] private RectTransform startPos;  
    [SerializeField] private RectTransform endPos;   
    [SerializeField] private float interpolationSpeed = 1f;
    [SerializeField] private float speedMultiplier;
    [SerializeField] private float speedMultiplierMultiplier;

    [Header("Objects")]
    [SerializeField] private GameObject pot;   
    [SerializeField] private GameObject particles;  

    private bool indicatorState = false;
    private bool stopIndicator = false;
    
   

    private void Start()
    {
      
        if (indicator != null && startPos != null)
        {
            indicator.position = startPos.position;
        }
        StartCoroutine(IndicatorStart());
    }
    private void Update()
    {
        if (indicatorState && Input.GetMouseButtonDown(0))
        {
            stopIndicator = true;
        }
    }
    public void Interact()
    {
       
    }
    private IEnumerator IndicatorStart()
    {
        yield return new WaitForSeconds(1f);
        indicatorState = true;
        pot.SetActive(true);
        particles.SetActive(true);
        while (Vector3.Distance(indicator.position, endPos.position) > INDICATOR_INTERPOLATION_MAX_TOLERANCE && !stopIndicator && indicator.position.y < endPos.position.y)
        {
            speedMultiplier *= speedMultiplierMultiplier;
            indicator.position = new Vector3(indicator.position.x, indicator.position.y * speedMultiplier, indicator.position.z);
            yield return null;
        }
        
        if (!stopIndicator)
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
        particles.SetActive(false);
        stopIndicator = false;
        indicatorState = false;
    }
}

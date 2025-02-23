using System;
using System.Collections;
using UnityEngine;

public class Cooker : MonoBehaviour, IInteractable
{
    #region Variables
    private const float INTERPOLATION_MAX_TOLERANCE = 0.05f;
    
    [SerializeField] private InteractManager interactManager;
    [Header("Camera Positions")]
    [SerializeField] private Transform cam;
    [SerializeField] private Transform camPosition;
    [SerializeField] private float interpolationSpeed = 1f;
    [Space(2f)]
    
    [Header("Cooker Settings")]
    [SerializeField] public int capacity;
    [SerializeField] private string currentRecipe;
    [Space(2f)]
    
    [Header("Local Canvas")]
    [SerializeField] private GameObject canvas;
    [Space(2f)]
    
    [Header("Indicator Settings")]
    [SerializeField] private RectTransform indicator; 
    [SerializeField] private RectTransform startPos;  
    [SerializeField] private RectTransform endPos;   
    [SerializeField] private float speed;
    [SerializeField] private float speedMultiplier;
    [SerializeField] private float speedMultiplierMultiplier;
    [SerializeField] private float delay;
    [Space(2f)]

    [Header("Objects")]
    [SerializeField] private GameObject pot;   
    [SerializeField] private GameObject particles;  
    

    private bool _indicatorState = false;
    private bool _stopIndicator = false;
    private CameraState _cameraState;
    
    #endregion
    private void Start()
    {
        
        interactManager = FindFirstObjectByType<InteractManager>();
        cam = Camera.main.transform;
        camPosition = transform.Find("CamPosition");
        _cameraState = cam.GetComponent<CameraState>();
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
        if (!_cameraState.isInterpolating)
        {
            cam.SetParent(this.transform);
            StartCoroutine(MoveCamera());
        }
        
    }

    private IEnumerator MoveCamera()
    {
        interactManager.canInteract = false;
        _cameraState.isInterpolating = true;
        while (Vector3.Distance(cam.position, camPosition.position) > INTERPOLATION_MAX_TOLERANCE || Quaternion.Angle(cam.rotation, camPosition.rotation) > INTERPOLATION_MAX_TOLERANCE)
        {
            cam.position = Vector3.Lerp(cam.position, camPosition.position, Time.deltaTime * interpolationSpeed);
            cam.rotation = Quaternion.Lerp(cam.rotation, camPosition.rotation, Time.deltaTime * interpolationSpeed);
            yield return null;
        }
        
        cam.position = camPosition.position;
        cam.rotation = camPosition.rotation;
        canvas.SetActive(true);
        StartCoroutine(IndicatorStart());
        interactManager.canInteract = true;
        _cameraState.isInterpolating = false;
    }
    private IEnumerator IndicatorStart()
    {
        yield return new WaitForSeconds(delay);
        _indicatorState = true;
        pot.SetActive(true);
        particles.SetActive(true);
        interactManager.canInteract = false;
        
        while (Vector3.Distance(indicator.position, endPos.position) > INTERPOLATION_MAX_TOLERANCE && !_stopIndicator && indicator.position.y < endPos.position.y)
        {
            speed *= speedMultiplierMultiplier;
            indicator.position = new Vector3(indicator.position.x, indicator.position.y * speed, indicator.position.z);
            yield return null;
        }
        
        if (!_stopIndicator)
            Debug.LogError("Over Cooked");
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

    public void ResetCooker()
    {
        speed = speedMultiplier;
        indicator.position = startPos.position;
        canvas.SetActive(false);
        pot.SetActive(false);
    }
}

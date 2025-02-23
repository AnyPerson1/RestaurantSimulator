using System;
using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
   private const float INTERPOLATION_MAX_TOLERANCE = 0.05f;
   
   private CameraState _cameraState;
   
   [SerializeField] private InteractManager interactManager;
   
   [SerializeField] private Vector3 startOffset;
   [SerializeField] private Vector3 startRotation;
   [SerializeField] private Transform cameraTransform;
   [SerializeField] private float interpolationSpeed = 8;
   private void Start()
   {
      _cameraState = cameraTransform.GetComponent<CameraState>();
      interactManager = FindFirstObjectByType<InteractManager>();
      ResetPosition();
   }

   public void ResetPosition()
   {
      if (!_cameraState.isInterpolating)
      {
         StartCoroutine(ResetCameraPosition());
      }
   }

   private IEnumerator ResetCameraPosition()
   {
      _cameraState.isInterpolating = true;
      cameraTransform.SetParent(transform);

      Vector3 targetPos = startOffset;
      Quaternion targetRot = Quaternion.Euler(startRotation);

      while (Vector3.Distance(cameraTransform.localPosition, targetPos) > INTERPOLATION_MAX_TOLERANCE ||
             Quaternion.Angle(cameraTransform.localRotation, targetRot) > INTERPOLATION_MAX_TOLERANCE)
      {
         cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, targetPos, Time.deltaTime * interpolationSpeed);
         cameraTransform.localRotation = Quaternion.Lerp(cameraTransform.localRotation, targetRot, Time.deltaTime * interpolationSpeed);
         yield return null;
      }


      cameraTransform.localPosition = targetPos;
      cameraTransform.localRotation = targetRot;
      _cameraState.isInterpolating = false;
   }
}

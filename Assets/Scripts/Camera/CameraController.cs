using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
   [SerializeField] private Vector3 startOffset;
   [SerializeField] private Transform cameraTransform;
   private void Start()
   {
      cameraTransform.localPosition = startOffset;
   }
}

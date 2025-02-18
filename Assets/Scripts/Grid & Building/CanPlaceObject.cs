using UnityEngine;
using System.Collections;

public class CanPlaceObject : MonoBehaviour
{
    public static bool isColliding = false;
    [SerializeField] private float checkInterval = 0.5f;

    private void Start()
    {
        StartCoroutine(CheckCollisionRoutine());
    }

    private void OnTriggerEnter(Collider other)
    {
        isColliding = true;
        Debug.Log("Colliding with: " + other.gameObject.name);
    }

    private void OnTriggerExit(Collider other)
    {
        isColliding = false;
        Debug.Log("No longer colliding with: " + other.gameObject.name);
    }

    private IEnumerator CheckCollisionRoutine()
    {
        while (true)
        {
            Debug.Log("Collision Status: " + isColliding);
            yield return new WaitForSeconds(checkInterval);
        }
    }

    public static bool CanPlace()
    {
        return isColliding;
    }
}

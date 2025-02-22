using UnityEngine;

public class CanPlaceObject : MonoBehaviour
{
    public static bool isColliding = false;
    public Vector3 boxSize = new Vector3(1, 1, 1);
    public LayerMask collisionMask;

    private void Update()
    {
        CheckForCollisions();
    }

    private void CheckForCollisions()
    {
        isColliding = Physics.CheckBox(transform.position, boxSize / 2, Quaternion.identity, collisionMask);
    }

    public static bool CanPlace()
    {
        return isColliding;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = isColliding ? Color.red : Color.green;
        Gizmos.DrawWireCube(transform.position, boxSize);
    }
}

using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    [Header("Cursor Settings")]
    [SerializeField] private GameObject mouseCursorPrefab;
    private Transform mouseCursorTransform;
    [SerializeField] GameObject TileCanPlaceCheckPrefab;
    private Transform tileCanPlaceCheckTransform;

    [Header("Placement Marker Settings")]
    [SerializeField] private GameObject placementMarkerPrefab;
    private Transform placementMarkerTransform;

    [SerializeField] private LayerMask placementLayer;
    [SerializeField] private GameObject objectToPlace;

    void Start()
    {
        GameObject mouseCursorInstance = Instantiate(mouseCursorPrefab, Vector3.zero, mouseCursorPrefab.transform.rotation);
        mouseCursorTransform = mouseCursorInstance.transform;

        GameObject placementMarkerInstance = Instantiate(placementMarkerPrefab, Vector3.zero, placementMarkerPrefab.transform.rotation);
        placementMarkerTransform = placementMarkerInstance.transform;

        GameObject TileCanPlaceCheckInstance = Instantiate(TileCanPlaceCheckPrefab, Vector3.zero, TileCanPlaceCheckPrefab.transform.rotation);
        tileCanPlaceCheckTransform = TileCanPlaceCheckInstance.transform;
    }

    void Update()
    {
        UpdateCursors();
        PlaceObject();
    }

    void UpdateCursors()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, placementLayer))
        {
            mouseCursorTransform.position = new Vector3(hit.point.x, 0, hit.point.z);

            GameObject[] placementNodes = GameObject.FindGameObjectsWithTag("PlacementNode");
            Transform nearestPlacementNode = FindNearestPlacementNode(placementNodes, mouseCursorTransform.position);

            if (nearestPlacementNode != null)
            {
                tileCanPlaceCheckTransform.position = nearestPlacementNode.position;

                placementMarkerTransform.position = Vector3.Lerp(
                    placementMarkerTransform.position,
                    nearestPlacementNode.position,
                    10f * Time.deltaTime
                );
            }
        }
    }

    Transform FindNearestPlacementNode(GameObject[] nodes, Vector3 currentPosition)
    {
        Transform nearestNode = null;
        float minDistance = Mathf.Infinity;

        foreach (GameObject node in nodes)
        {
            float distance = Vector3.Distance(currentPosition, node.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestNode = node.transform;
            }
        }

        return nearestNode;
    }

    void PlaceObject()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject[] placementNodes = GameObject.FindGameObjectsWithTag("PlacementNode");

            if (placementNodes.Length == 0)
            {
                Debug.LogWarning("No Placement Nodes Found!");
                return;
            }

            Transform nearestPlacementNode = FindNearestPlacementNode(placementNodes, mouseCursorTransform.position);

            if (nearestPlacementNode != null && !CanPlaceObject.CanPlace())
            {
                Instantiate(objectToPlace, nearestPlacementNode.position, objectToPlace.transform.rotation);
            }
        }
    }
}

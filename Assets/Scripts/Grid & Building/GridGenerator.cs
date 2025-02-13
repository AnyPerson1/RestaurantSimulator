using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField] GameObject GridPlaceHolder;



    void Start()
    {
        Instantiate(GridPlaceHolder, transform.position + new Vector3(2, 0, 0), Quaternion.identity);
        Instantiate(GridPlaceHolder, transform.position + new Vector3(-2, 0, 0), Quaternion.identity);
        Instantiate(GridPlaceHolder, transform.position + new Vector3(0, 0, 2), Quaternion.identity);
        Instantiate(GridPlaceHolder, transform.position + new Vector3(0, 0, -2), Quaternion.identity);
    }
}

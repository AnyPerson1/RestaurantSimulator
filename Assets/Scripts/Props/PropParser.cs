using UnityEngine;

public class PropParser : MonoBehaviour
{
    public enum PropType{
        Counter,
        Cooker,
        Table,
        Furnace,
        Storage,
        Ingredient
    }

    [SerializeField] public PropType type;
    
}

using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class RecipePanel : MonoBehaviour
{
    [SerializeField] private StorageManager globalStorage;
    [SerializeField] private GameObject noSourceFoundText;
    
    [SerializeField] private RectTransform ingredientSlotParent;
    [SerializeField] private RectTransform recipeSlotParent;

    [SerializeField] private GameObject ingredientSlotPrefab;
    [SerializeField] private GameObject recipeSlotPrefab;

    [SerializeField] public List<Ingredient> ingredients;

    private void Awake()
    {
        GameObject globalStorageObject = GameObject.FindWithTag("GlobalStorage");
        if (globalStorageObject != null)
        {
            globalStorage = globalStorageObject.GetComponent<StorageManager>();
            if (globalStorage == null)
            {
                Debug.LogError("StorageManager component not found on GlobalStorage object.");
            }
        }
        else
        {
            Debug.LogError("GlobalStorage object with tag 'GlobalStorage' not found.");
        }
    }

    private void Start()
    {
        ReloadPanel();
    }

    public void ReloadPanel()
    {
        ingredients = globalStorage.storedIngredients;
        if (globalStorage == null)
        {
            Debug.LogError("GlobalStorage is not assigned.");
            return;
        }

        foreach (Transform child in ingredientSlotParent.transform)
        {
            Destroy(child.gameObject);
        }

        if (ingredients.Count <= 0)
        {
            noSourceFoundText.SetActive(true);
            return;
        }
        else
            noSourceFoundText.SetActive(false);
        
        foreach (Ingredient ingredient in ingredients)
        {
            GameObject element = Instantiate(ingredientSlotPrefab, ingredientSlotParent.transform);
            element.transform.GetChild(0).GetComponent<Image>().sprite = GetSpriteOfIngredient(ingredient.ingredientType);
            element.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = ingredient.amount.ToString();
        }
    }

    private Sprite GetSpriteOfIngredient(Ingredient.Type ingredientType)
    {
        Sprite sprite = Resources.Load<Sprite>(ingredientType.ToString());
        if (sprite == null)
        {
            Debug.LogError($"Sprite not found for ingredient: {ingredientType}");
        }
        return sprite;
    }
}
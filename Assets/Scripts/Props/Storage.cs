using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Storage : MonoBehaviour
{
    [SerializeField] public int maxStorage = 100;
    [SerializeField] public int currentStorage = 0;
    [SerializeField] private StorageManager storageManager;
    [SerializeField] public List<Ingredient> ingredients = new List<Ingredient>();

    private void Start()
    {
        storageManager = GameObject.FindGameObjectWithTag("GlobalStorage").GetComponent<StorageManager>();
        if (!storageManager.storagesInScene.Contains(this))
            storageManager.storagesInScene.Add(this);
        else
            Debug.Log("Some 'Storage' class tried to add itself to global storage list more than one time");
    }
}

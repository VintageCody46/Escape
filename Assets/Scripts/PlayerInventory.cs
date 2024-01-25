using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public TextMeshProUGUI keyText;

    public List<GameObject> Keys = new List<GameObject>();

    private int numKeys;

    public void IncrementKeys(GameObject key)
    {
        Keys.Add(key);
        
    }

    public void DecrrementKeys()
    {
        
    }
}

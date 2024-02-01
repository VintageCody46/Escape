using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public TextMeshProUGUI keyText;

    public List<Key> Keys = new List<Key>();

    private int numKeys;

    public void IncrementKeys(Key key)
    {
        Keys.Add(key);
        keyText.text = "X " + Keys.Count.ToString();
    }

    public void DecrementKeys(string gateColor)
    {
        for (int i = 0; i < Keys.Count; i++)
        {
            if (gateColor == Keys[i].keyColor)
            {
                Keys.Remove(Keys[i]);
                keyText.text = "X " + Keys.Count.ToString();
            }
        }
    }

    public int GetKeys()
    {
        return Keys.Count;
    }

    public bool ColorMatch(string gateColor)
    {
        for (int i = 0; i < Keys.Count; i++)
        {
            if (gateColor == Keys[i].keyColor)
            {
                return true;
            }
        }

        return false;
    }
}

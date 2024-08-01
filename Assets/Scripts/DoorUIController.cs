using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUIController : MonoBehaviour
{
    private Canvas doorUICanvas;

    // Start is called before the first frame update
    void Start()
    {
        
        doorUICanvas = GetComponentInChildren<Canvas>();
        doorUICanvas.enabled = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        doorUICanvas.enabled = true;
    }

    public void OnTriggerExit(Collider other)
    {
        doorUICanvas.enabled = false;
    }
}

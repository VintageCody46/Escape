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
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            doorUICanvas.enabled = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            doorUICanvas.enabled = false;
        }
    }
}

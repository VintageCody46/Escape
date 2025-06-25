using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUIController : MonoBehaviour
{
    //public Transform target;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerUI pui = other.gameObject.GetComponent<PlayerUI>();
            
            pui.playerUICanvas.enabled = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            PlayerUI pui = other.gameObject.GetComponent<PlayerUI>();

            pui.playerUICanvas.enabled = false;
        }
    }
}

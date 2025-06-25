using System.Collections;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Vector3 currentRot;

    public GameObject door;
    public float openRot;
    public float closeRot;
    public float speed;
    public bool open;
    public bool playerInCollider;


    private void Update()
    {
        currentRot = door.transform.localEulerAngles;

        if (playerInCollider)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                open = !open;
            }
        }

        if (open)
        {
            OpenDoor();
        }
        else
        {
            CloseDoor();
        }



    }

    public void OpenDoor()
    {
        if (currentRot.y < openRot)
        {
            door.transform.localEulerAngles = Vector3.Lerp(currentRot, new Vector3(currentRot.x, openRot, currentRot.z), speed * Time.deltaTime);
        }
    }

    public void CloseDoor()
    {
        if (currentRot.y > closeRot)
        {
            door.transform.localEulerAngles = Vector3.Lerp(currentRot, new Vector3(currentRot.x, closeRot, currentRot.z), speed * Time.deltaTime);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            playerInCollider = true;   
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            playerInCollider = false;
        }
    }
}
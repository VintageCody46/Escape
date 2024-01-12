using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCameraMovement : MonoBehaviour
{
    public float mouseSensitivity  = 100f;

    //public Transform orientation;

    private float xRot;
    private float yRot;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Mouse Input
        Vector2 looking = Mouse.current.delta.ReadValue();

        xRot = looking.x * Time.deltaTime * mouseSensitivity;
        yRot = looking.y * Time.deltaTime * mouseSensitivity;

        transform.Rotate(Vector3.up, xRot);
        
        Camera.main.transform.Rotate(Vector3.left, yRot);
    }
}

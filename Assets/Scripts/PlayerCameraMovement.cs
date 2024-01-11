using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCameraMovement : MonoBehaviour
{
    public float mouseSensitivity  = 100f;

    public Transform orientation;

    float xRot;
    float yRot;
    
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
        //float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;
        //float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;


        Debug.Log(Mouse.current.delta.ReadValue());

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        //Rotation of the camera
        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        orientation.Rotate(Vector3.up * mouseX);
    }
}

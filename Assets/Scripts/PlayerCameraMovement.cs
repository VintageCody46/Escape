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
        Vector2 looking = Mouse.current.delta.ReadValue();

        float mouseX = looking.x * Time.deltaTime * mouseSensitivity;
        float mouseY = looking.y * Time.deltaTime * mouseSensitivity;

        yRot += mouseX;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        //Rotation of the camera
        transform.localRotation = Quaternion.Euler(xRot, yRot, 0f);
        orientation.localRotation = Quaternion.Euler(0f, yRot, 0f);
    }
}

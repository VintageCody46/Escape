using JetBrains.Rider.Unity.Editor;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput pi;
    
    private float moveX;
    private float moveZ;

    public float speed = 12f;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        pi = new PlayerInput();
        pi.Enable();

        pi.Player.Movement.performed += OnMovement;
        pi.Player.Movement.canceled += OnMovement;

        rb = GetComponent<Rigidbody>();
    }

    private void OnMovement(InputAction.CallbackContext obj)
    {
        Vector2 movementVal = obj.ReadValue<Vector2>();
        moveX = movementVal.x;
        moveZ = movementVal.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moveX == 0 && moveZ == 0)
        {
            rb.velocity = Vector2.zero;
        }

        else
        {
            Vector3 move = transform.right * moveX + transform.forward * moveZ;
            rb.velocity += move * speed * Time.fixedDeltaTime;
        }
    }
}

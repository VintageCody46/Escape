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
    public float decel;

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
            if (Mathf.Abs(rb.velocity.x) > decel)
            {
                Vector3 move = transform.right * decel;
                rb.velocity -= move * speed * Time.fixedDeltaTime;
                Debug.Log("Deceleration after done inputting sideways " + rb.velocity);
            }
            else
            {
                rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
                Debug.Log("Should be stopped " + rb.velocity);
            }

            if (Mathf.Abs(rb.velocity.z) > decel)
            {
                Vector3 move = transform.forward * decel;
                rb.velocity -= move * speed * Time.fixedDeltaTime;
                Debug.Log("Deceleration after done inputting sideways " + rb.velocity);
            }
            else
            {
                rb.velocity = new Vector3(rb.velocity.z, rb.velocity.y, 0); 
                Debug.Log("Should be stopped " + rb.velocity);
            }
        }

        else
        {
            Vector3 move = transform.right * moveX + transform.forward * moveZ;
            rb.velocity += move * speed * Time.fixedDeltaTime;
            Debug.Log("Acceleration of the input variety " + rb.velocity);
        }
    }
}

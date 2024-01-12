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

    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        pi = new PlayerInput();
        pi.Enable();

        pi.Player.Movement.performed += OnMovement;
        pi.Player.Movement.canceled += OnMovement;

        controller = GetComponent<CharacterController>();
    }

    private void OnMovement(InputAction.CallbackContext obj)
    {
        Vector2 movementVal = obj.ReadValue<Vector2>();
        moveX = movementVal.x;
        moveZ = movementVal.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        controller.Move(move * speed * Time.deltaTime);
    }
}

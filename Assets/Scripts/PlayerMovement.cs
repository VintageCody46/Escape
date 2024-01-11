using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput pi;
    
    public float x;
    public float z;

    public float speed = 12f;

    public CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        pi = new PlayerInput();
        pi.Player.Movement.performed += OnMovement;
    }

    private void OnMovement(InputAction.CallbackContext obj)
    {
        Vector2 movementVal = obj.ReadValue<Vector2>();
        x = movementVal.x;
        z = movementVal.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
    }
}

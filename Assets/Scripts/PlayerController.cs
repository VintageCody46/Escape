using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
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
        Vector3 move = new Vector3(moveX, 0, moveZ);

        transform.Translate(move * speed * Time.fixedDeltaTime , Space.Self);
    }
}

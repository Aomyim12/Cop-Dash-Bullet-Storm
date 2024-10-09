using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 movementInput;
    private Rigidbody2D rb;
    private PlayerControls controls;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        controls = new PlayerControls();
    }

    private void OnEnable()
    {
        // Enable the input actions
        controls.Player.Move.performed += OnMovementInput;
        controls.Player.Move.canceled += OnMovementInput;
        controls.Enable();
    }

    private void OnDisable()
    {
        // Disable the input actions
        controls.Player.Move.performed -= OnMovementInput;
        controls.Player.Move.canceled -= OnMovementInput;
        controls.Disable();
    }

    private void OnMovementInput(InputAction.CallbackContext context)
    {
        // Update the movement input value
        movementInput = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        // Move the player using the Rigidbody
        rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // ความเร็วเริ่มต้นในการเคลื่อนที่
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
        controls.Player.Move.performed += OnMovementInput;
        controls.Player.Move.canceled += OnMovementInput;
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Move.performed -= OnMovementInput;
        controls.Player.Move.canceled -= OnMovementInput;
        controls.Disable();
    }

    private void OnMovementInput(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        // ใช้ค่า moveSpeed ที่อัปเกรดแล้ว
        rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);
    }

    // ฟังก์ชันที่ใช้ในการอัปเกรด Speed Boost
    public void UpgradeSpeedBoost(float newMoveSpeed)
    {
        moveSpeed = newMoveSpeed;
    }
}

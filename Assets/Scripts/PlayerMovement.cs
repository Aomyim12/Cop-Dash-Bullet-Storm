using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // ���������������㹡������͹���
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
        // ���� moveSpeed ����ѻ�ô����
        rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);
    }

    // �ѧ��ѹ�����㹡���ѻ�ô Speed Boost
    public void UpgradeSpeedBoost(float newMoveSpeed)
    {
        moveSpeed = newMoveSpeed;
    }
}

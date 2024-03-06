using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.Video;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    private InputManager inputManager;

    public bool playerJumped;
    public bool isGrounded = true;

    private Vector2 movementInput;
    private Vector3 move;
    private Vector3 verticalVelocity;
    private Transform playerTransform;

    [SerializeField] private Transform groundCheckTransform;
    [SerializeField] private LayerMask groundLayerMask;

    public float movementSpeed = 10f;
    public float gravity = -14f;
    public float groundedRadius = 0.5f;
    public float jumpHeight = 1.9f;

    private void Awake() {
        inputManager = GetComponent<InputManager>();
        characterController = GetComponent<CharacterController>();

        playerTransform = transform;
    }

    private void Update() {        

        Move();
        JumpAndGravity();
    }

    private void Move() {
        movementInput = inputManager.GetPlayerMovement();
        move = transform.right * movementInput.x + transform.forward * movementInput.y;

        characterController.Move(move * movementSpeed * Time.deltaTime);
    }

    private void JumpAndGravity() {

        isGrounded = Physics.CheckSphere(groundCheckTransform.position, groundedRadius, groundLayerMask);
        playerJumped = inputManager.PlayerJumped();

        if (isGrounded && playerJumped) {
            verticalVelocity.y = Mathf.Sqrt(gravity * -2f * jumpHeight);
        }

        if (isGrounded && verticalVelocity.y < 0) {
            verticalVelocity.y = -2f;
        }

        verticalVelocity.y += gravity * Time.deltaTime;
        characterController.Move(verticalVelocity * Time.deltaTime);
    }
}

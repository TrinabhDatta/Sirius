using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour {
    
    private InputManager inputManager;

    private float xRotation;
    private float mouseX;
    private float mouseY;

    public float mouseSensitivity = 100f;

    [SerializeField] private Camera playerCamera;
    
    private Transform playerTransform;
    private Transform cameraTransform;

    private Vector2 mouseInput;

    private void Awake() {
        inputManager = GetComponent<InputManager>();    

        cameraTransform = playerCamera.transform;
        playerTransform = transform;
    }

    public void Update() {
        Look();
    }

    public void Look() {
        mouseInput = inputManager.GetMouseDelta();

        mouseX = mouseInput.x * mouseSensitivity * Time.deltaTime;
        mouseY = mouseInput.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerTransform.Rotate(Vector3.up * mouseX);
    }
}
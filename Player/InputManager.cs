using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private InputMaster inputMaster;

    private void Awake() {
        inputMaster = new InputMaster();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnEnable() {
        inputMaster.Enable();
    }

    private void OnDisable() {
        inputMaster.Disable();
    }

    public Vector2 GetMouseDelta() {
        return inputMaster.Player.MouseLook.ReadValue<Vector2>();
    }

    public Vector2 GetPlayerMovement() {
        return inputMaster.Player.Movement.ReadValue<Vector2>();
    }

    public bool PlayerJumped() {
        return inputMaster.Player.Jump.triggered;
    }
}

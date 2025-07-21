using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private PlayerInputSystem playerInputSystem;
    public event EventHandler OnPressE;
    private void OnEnable()
    {
        playerInputSystem.Enable();
        playerInputSystem.Player.Interact.performed += OnPlayerPressE;
    }

    private void OnDisable()
    {
        playerInputSystem.Disable();
        playerInputSystem.Player.Interact.performed -= OnPlayerPressE;
    }
    private void Awake()
    {
        playerInputSystem = new PlayerInputSystem();
    }
    private void OnPlayerPressE(InputAction.CallbackContext context)
    {
        OnPressE?.Invoke(this, EventArgs.Empty);
    }
    public Vector2 GetMovmentVector()
    {
        Vector2 inputVector = playerInputSystem.Player.Move.ReadValue<Vector2>();
        inputVector = inputVector.normalized;
        return inputVector;
    }
}

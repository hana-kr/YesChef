using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private PlayerInputSystem playerInputSystem;
    public event EventHandler OnPressE;
    public event EventHandler OnPressF;
    private void OnEnable()
    {
        playerInputSystem.Enable();
        playerInputSystem.UI.Enable();
        playerInputSystem.Player.Interact.performed += OnPlayerPressE;
        playerInputSystem.Player.InteractAlter.performed += OnPlayerPressF;
    }


    private void OnDisable()
    {
        playerInputSystem.Disable();
        playerInputSystem.Player.Interact.performed -= OnPlayerPressE;
        playerInputSystem.Player.InteractAlter.performed -= OnPlayerPressF;
    }
    private void Awake()
    {
        playerInputSystem = new PlayerInputSystem();
    }
    private void OnPlayerPressE(InputAction.CallbackContext context)
    {
        OnPressE?.Invoke(this, EventArgs.Empty);
    }
    private void OnPlayerPressF(InputAction.CallbackContext context)
    {
        OnPressF?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovmentVector()
    {
        Vector2 inputVector = playerInputSystem.Player.Move.ReadValue<Vector2>();
        inputVector = inputVector.normalized;
        return inputVector;
    }
}

using ProjectX.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputTest : MonoBehaviour
{
    private Vector2 _movement;
    private bool _isJump;
    private GameInput _gameInput;
    private void Awake()
    {
        _gameInput = new GameInput();
    }

    private void OnEnable()
    {
        _gameInput.Enable();
        _gameInput.Player.Movement.performed += OnMovement;
        _gameInput.Player.Jump.performed += OnJumped;
    }
    private void OnDisable()
    {
        _gameInput.Player.Movement.performed -= OnMovement;
        _gameInput.Player.Jump.performed -= OnJumped;
        _gameInput.Disable();
    }
    private void OnJumped(InputAction.CallbackContext context)
    {
        OnJump();
    }
    private void OnJump()
    {
        _isJump = _gameInput.Player.Jump.triggered;
    }
    private void OnMovement(InputAction.CallbackContext context)
    {
        OnMove();
    }

    private void OnMove()
    {
        _movement = _gameInput.Player.Movement.ReadValue<Vector2>();
    }
    private void Update()
    {
        OnMove();
        OnJump();

    }
    public float GetHorizontalInput()
    {
        return _movement.x;
    }
    public float GetVerticalInput()
    {
        return _movement.y;
    }
    public bool GetJumpInput()
    {
        return _isJump;
    }

}

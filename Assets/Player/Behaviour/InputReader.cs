using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class InputReader : MonoBehaviour
{
    public PlayerController player;
    private InputManager inputManager;
    
    [SerializeField] private Vector2 inputDirection;
    void Start()
    {
        inputManager = new InputManager();
    
        inputManager.Enable();
        
        inputManager.Player.Movement.performed += ctx => Move(ctx.ReadValue<Vector2>());
        inputManager.Player.Movement.canceled += ctx => Move(ctx.ReadValue<Vector2>());
        inputManager.Player.Jump.performed += ctx => Jump();
    }

    void Move(Vector2 direction)
    {
        inputDirection = direction;
    }

    void Jump()
    {
        player.GetMovementController().Jump();
    }

    public Vector2 GetInputMovement()
    {
        return inputDirection;
    }
}

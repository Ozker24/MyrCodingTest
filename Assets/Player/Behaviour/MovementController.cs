using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public PlayerController player;
    [SerializeField] private CharacterController characterController;
    [Header("Movement")]
    [SerializeField] private Vector3 movementDirection;
    [SerializeField] private float speed;
    [Header("Jump")]
    [SerializeField] private float jumpPower;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] bool isGrounded;

    public float GetSpeed()
    {
        return speed;
    }
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
    public void AddSpeed(float newSpeed)
    {
        speed += newSpeed;
    }
    
    public float GetJumpPower()
    {
        return jumpPower;
    }
    public void SetJumpPower(float newPower)
    {
        jumpPower = newPower;
    }
    public void AddJumpPower(float newJumpPower)
    {
        jumpPower += newJumpPower;
    }

    private void Start()
    {
        characterController = GetComponentInParent<CharacterController>();
    }

    private void Update()
    {
        isGrounded = characterController.isGrounded;

        Move();
    }

    public void Jump()
    {
        if (isGrounded) movementDirection.y = Mathf.Sqrt(jumpPower * -3.0f * gravityValue);
    }

    private void Move()
    {
        if (isGrounded && movementDirection.y < 0) movementDirection.y = 0f;

        movementDirection.x = player.GetInputReader().GetInputMovement().x;
        movementDirection.z = player.GetInputReader().GetInputMovement().y;

        movementDirection.y += gravityValue * Time.deltaTime;
        characterController.Move(movementDirection * Time.deltaTime * speed);
    }
}

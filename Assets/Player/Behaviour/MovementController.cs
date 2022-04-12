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

    public void SetSpeed(float newSpeed)
    {
        speed += newSpeed;
    }
    public void SetJumpPower(float newJumpPower)
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
        if (isGrounded)
        {
            Debug.Log("Jump");
            movementDirection.y += Mathf.Sqrt(jumpPower * -3.0f * gravityValue);
        }
    }

    private void Move()
    {
        if (isGrounded && movementDirection.y < 0) movementDirection.y = 0f;

        movementDirection.x = player.GetInputReader().GetInputMovement().x;
        movementDirection.z = player.GetInputReader().GetInputMovement().y;
        
        characterController.Move(movementDirection * Time.deltaTime * speed);

        movementDirection.y += gravityValue * Time.deltaTime;
        characterController.Move(movementDirection * Time.deltaTime);
    }
}

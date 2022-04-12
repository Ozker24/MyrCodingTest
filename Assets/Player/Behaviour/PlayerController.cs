using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Components")]
    [SerializeField] private PowerUpCollector powerUpCollector;
    [SerializeField] private MovementController movementController;
    [SerializeField] private InputReader inputReader;

    public InputReader GetInputReader()
    {
        return inputReader;
    }   

    public MovementController GetMovementController()
    {
        return movementController;
    }

    void Start()
    {
        SetUpComponents();
        SetPlayerToComponent();
    }

    private void SetUpComponents()
    {
        powerUpCollector = GetComponentInChildren<PowerUpCollector>();
        movementController = GetComponentInChildren<MovementController>();
        inputReader = GetComponentInChildren<InputReader>();
    }

    private void SetPlayerToComponent()
    {
        powerUpCollector.player = this;
        movementController.player = this;
        inputReader.player = this;
    }
}

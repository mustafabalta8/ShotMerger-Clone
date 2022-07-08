using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [Header("Movement")]
    [SerializeField] private Vector3 movementDirection;
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float swerveSpeed;
    [SerializeField] private float sideMovementLimit;

    [Header("Colon")]
    [SerializeField] private Transform colonParent;
    public Transform ColonParent { get => colonParent; }

    private void Start()
    {
        instance = this;
    }
    void Update()
    {
        if (GameManager.GameState == GameStates.InGame)
        {
            MoveForward();
            HandleSideMove();
        }

    }

    private void MoveForward()
    {
        transform.Translate(movementDirection * Time.deltaTime * forwardSpeed);//

    }
    private void HandleSideMove()
    {
        float swerveAmount = swerveSpeed * InputManager.instance.MoveFactorX * Time.deltaTime;

        var currentPos = transform.position;
        currentPos.x += swerveAmount;
        currentPos.x = Mathf.Clamp(currentPos.x, -sideMovementLimit, sideMovementLimit);

        transform.position = currentPos;//Mathf.SmoothDamp??
    }
    
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(Rigidbody2D))]
public class AgentMovement : MonoBehaviour
{
    protected Rigidbody2D rigid;

    [field: SerializeField]
    public MovementDataSO MovementData { get; set; }
    
    [SerializeField]
    protected float currentVelocity = 3;
    protected Vector2 movementDirection;

    [field: SerializeField]
    public UnityEvent<float> OnVelocityChange { get; set; }
    
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    public void MoveAgent(Vector2 movementInput)
    {
        if (movementInput.magnitude > 0)
        {
            if (Vector2.Dot(movementInput.normalized, movementDirection) < 0)
            {
                currentVelocity = 0;
            }
            movementDirection = movementInput;
        }
        
        currentVelocity = CalculateSpeed(movementInput);
    }

    private float CalculateSpeed(Vector2 movementInput)
    {
        if (movementInput.magnitude > 0)
        {
            currentVelocity += MovementData.acceleration * Time.deltaTime;
        }
        else
        {
            currentVelocity -= MovementData.acceleration * Time.deltaTime;
        }

        return Mathf.Clamp(currentVelocity, 0, MovementData.maxSpeed);
    }

    private void FixedUpdate()
    {
        OnVelocityChange?.Invoke(currentVelocity);
        rigid.velocity = currentVelocity * movementDirection.normalized;
        
    }
}

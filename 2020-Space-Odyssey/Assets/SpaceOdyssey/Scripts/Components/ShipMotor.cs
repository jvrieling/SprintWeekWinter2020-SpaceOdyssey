using UnityEngine;
using System.Collections;

public class ShipMotor : MonoBehaviour
{
    public float AccelerationTime = 1;
    public float DecelerationTime = 1;

    //*
    public float baseMaxSpeed = 1;
    public float MaxSpeed = 1;

    private float velocity;
    private Vector2 lastInput;

    /// <summary>
    /// Move the ship using it's transform only based on the current input vector. Do not use rigid bodies.
    /// </summary>
    /// <param name="input">The input from the player. The possible range of values for x and y are from -1 to 1.</param>
    public void HandleMovementInput( Vector2 input )
    {
        float velIncreasePerSecond = MaxSpeed / AccelerationTime;
        float velDecreasePerSecond = MaxSpeed / DecelerationTime;
        if (input.x != 0 || input.y != 0) velocity += velIncreasePerSecond * Time.deltaTime;
        else
        {
            if(velocity > 0) velocity -= velDecreasePerSecond * Time.deltaTime;
            if(velocity < 0) velocity += velDecreasePerSecond * Time.deltaTime;
        }

        velocity = Mathf.Clamp(velocity, -MaxSpeed, MaxSpeed);
        if ((velocity <= 0.05 && velocity >= -0.05) && (input.x == 0 && input.y == 0)) velocity = 0;

        float moveX = 0, moveY = 0;

        if (input.x != 0) moveX = (velocity * Time.deltaTime) * input.x;

        if (input.y != 0) moveY = (velocity * Time.deltaTime) * input.y;

        if(input.x == 0 && input.y == 0)
        {
            moveX = (velocity * Time.deltaTime) * lastInput.x;
            moveY = (velocity * Time.deltaTime) * lastInput.y;
        }

        Vector3 move = new Vector3(moveX, moveY, 0);

        transform.Translate(move, Space.World);

        if (input.x != 0 || input.y != 0) lastInput = input;
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private ShipMotor motor;
    void Awake()
    {
        motor = GetComponent<ShipMotor>();
    }

    
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        motor.HandleMovementInput(input);
    }
}

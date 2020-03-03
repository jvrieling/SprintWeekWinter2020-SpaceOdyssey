using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDownScreen : MonoBehaviour
{
    public float moveSpeed;


    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        //TODO: Check for modifiers
    }

    
    void Update()
    {
        transform.Translate(new Vector3(0, -moveSpeed, 0)*Time.deltaTime);
    }

    public void UpdateMoveSpeed(float newSpeed)
    {
        moveSpeed = newSpeed;
    }
}

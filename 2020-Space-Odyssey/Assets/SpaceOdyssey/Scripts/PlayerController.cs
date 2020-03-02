using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public bool canShoot = true;

    private ShipMotor motor;

    public PlayerDamagedEvent damageEvent;
    public PlayerShootEvent shootEvent;

    void Awake()
    {
        motor = GetComponent<ShipMotor>();
    }


    void Update()
    {
        //Use the ship motor from a past assignment.
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        motor.HandleMovementInput(input);

        if (Input.GetAxisRaw("Fire1") == 1 && canShoot)
        {
            shootEvent.Invoke();
            canShoot = false;
            Instantiate(bulletPrefab, transform.position, Quaternion.identity).gameObject.name = "Player Bullet";
        }
        else if (Input.GetAxisRaw("Fire1") == 0)
        {
            canShoot = true;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            damageEvent.Invoke();
        }
    }
}

[System.Serializable]
public class PlayerDamagedEvent : UnityEvent {}
[System.Serializable]
public class PlayerShootEvent : UnityEvent { }

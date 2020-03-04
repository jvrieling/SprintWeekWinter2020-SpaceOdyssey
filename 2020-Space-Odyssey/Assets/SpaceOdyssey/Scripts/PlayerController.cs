using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public ObjectManager objectManager;

    public GameObject bulletPrefab;
    public bool canShoot = true;
    public int maxBullets;

    private ShipMotor motor;

    public PlayerDamagedEvent damageEvent;
    public PlayerShootEvent shootEvent;

    public int playerNumber;

    void Awake()
    {
        motor = GetComponent<ShipMotor>();
    }
    public bool Getbool()
    { return canShoot; }

    void Update()
    {
        //Use the ship motor from a past assignment.
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal_P" + playerNumber), Input.GetAxisRaw("Vertical_P" + playerNumber));

        motor.HandleMovementInput(input);

        if (Input.GetAxisRaw("Fire1_P" + playerNumber) == 1 && canShoot && objectManager.playerBullets.Count < maxBullets)
        {
            shootEvent.Invoke();
            canShoot = false;
            GameObject tempBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            tempBullet.name = "Player Bullet";
            tempBullet.GetComponent<PlayerBullet>().owner = this;
            objectManager.playerBullets.Add(tempBullet.GetComponent<PlayerBullet>());
            AudioManager.instance.Play("Laser");
        }
        else if (Input.GetAxisRaw("Fire1_P" + playerNumber) == 0)
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
    public void DestroyBullet(PlayerBullet bullet)
    {
        objectManager.playerBullets.Remove(bullet);
    }

    public void addScore()
    {

    }

}



[System.Serializable]
public class PlayerDamagedEvent : UnityEvent {}
[System.Serializable]
public class PlayerShootEvent : UnityEvent { }

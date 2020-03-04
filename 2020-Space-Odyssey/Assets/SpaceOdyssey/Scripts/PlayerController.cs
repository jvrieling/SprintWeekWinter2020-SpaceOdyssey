using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public ObjectManager objectManager;

    public GameObject bulletPrefab;
    private bool canShoot = true;
    public List<PlayerBullet> bullets;
    public int maxBullets;

    private ShipMotor motor;

    public PlayerDamagedEvent damageEvent;
    public PlayerShootEvent shootEvent;

    //*
    public int playerNumber;
    public Camera gameCamera;
    private new CircleCollider2D collider;

    void Awake()
    {
        motor = GetComponent<ShipMotor>();
        bullets = new List<PlayerBullet>();

        if (!gameCamera)
            gameCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        if (!collider && GetComponent<CircleCollider2D>())
            collider = GetComponent<CircleCollider2D>();
    }


    void Update()
    {
        BoundaryCheckCircle();

        //Use the ship motor from a past assignment.
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal_P" + playerNumber), Input.GetAxisRaw("Vertical_P" + playerNumber));

        motor.HandleMovementInput(input);

        if (Input.GetAxisRaw("Fire1_P" + playerNumber) == 1 && canShoot && bullets.Count < maxBullets)
        {
            shootEvent.Invoke();
            canShoot = false;
            GameObject tempBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            tempBullet.name = "Player Bullet";
            tempBullet.GetComponent<PlayerBullet>().owner = this;
            objectManager.playerBullets.Add(tempBullet.GetComponent<PlayerBullet>());
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

    /* BoundaryCheckCircle()
     * ----------------
     * Locks the player to the Camera boundaries.
     * Includes a collider size check for its RADIUS (so it doesnt move off screen).
     */
    void BoundaryCheckCircle()
    {
        Vector2 topRightCorner = new Vector2(1, 1);
        Vector2 edgeVector = gameCamera.ViewportToWorldPoint(topRightCorner);

        float height = edgeVector.y * 2;
        float width = edgeVector.x * 2;

        switch(playerNumber) 
        {
            case 1: //Left side
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, -width / 2 + collider.radius, 0 - collider.radius),
                                        Mathf.Clamp(transform.position.y, -height / 2 + collider.radius, height / 2 - collider.radius),
                                        transform.position.z);

                break;

            case 2: //Right side
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, 0 + collider.radius, width / 2 - collider.radius),
                                        Mathf.Clamp(transform.position.y, -height / 2 + collider.radius, height / 2 - collider.radius),
                                        transform.position.z);
                break;
        }
    }

}

[System.Serializable]
public class PlayerDamagedEvent : UnityEvent {}
[System.Serializable]
public class PlayerShootEvent : UnityEvent { }

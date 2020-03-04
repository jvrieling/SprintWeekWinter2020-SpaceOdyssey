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

    //public PlayerDamagedEvent damageEvent;
    //public PlayerShootEvent shootEvent;

    public int playerNumber;
    public Camera gameCamera;
    private new CircleCollider2D collider;

    public int score;
    public int lives;

    public bool isDead = false;
    public float respawnTime = 1f;
    private float timeToRespawn = 0;
    private Vector3 initalPosition;

    public bool invincible = false;
    public float invicibilityTime = 2;
    private float invicibilityLeft;

    void Awake()
    {
        motor = GetComponent<ShipMotor>();

        if (!gameCamera)
            gameCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        if (!collider && GetComponent<CircleCollider2D>())
            collider = GetComponent<CircleCollider2D>();

        initalPosition = transform.position;
    }
    public bool Getbool()
    { return canShoot; }

    void Update()
    {
        BoundaryCheckCircle();

        //Use the ship motor from a past assignment.
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal_P" + playerNumber), Input.GetAxisRaw("Vertical_P" + playerNumber));

        motor.HandleMovementInput(input);

        if (Input.GetAxisRaw("Fire1_P" + playerNumber) == 1 && canShoot && objectManager.playerBullets.Count < maxBullets)
        {
            //shootEvent.Invoke();
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

        if (isDead)
        {
            timeToRespawn -= Time.deltaTime;
            if(timeToRespawn <= 0)
            {
                Respawn();
            }
        }
        if (invincible)
        {
            invicibilityLeft -= Time.deltaTime;
            if(invicibilityLeft <= 0)
            {
                invincible = false;
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!invincible && (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet"))
        {
            //damageEvent.Invoke();
            Debug.Log("Hit an enemy!!");
            KillPlayer();
        }
    }
    public void KillPlayer()
    {
        isDead = true;
        timeToRespawn = respawnTime;
        transform.position = new Vector3(-1000, -1000, 1000);
    }
    public void Respawn()
    {        
        if(lives > 0)
        {
            AddLives(-1);
            isDead = false;
            transform.position = initalPosition;
            invincible = true;
            invicibilityLeft = invicibilityTime;
        }
    }

    public void DestroyBullet(PlayerBullet bullet)
    {
        objectManager.playerBullets.Remove(bullet);
    }


    public void AddScore(int amt)
    {
        score += amt;
        AudioManager.instance.Play("Points");
    }
    public void AddLives(int amt)
    {
        lives += amt;
        if(amt > 0)
        {
            AudioManager.instance.Play("GainLives");
        } else
        {
            AudioManager.instance.Play("LoseLives");
        }
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

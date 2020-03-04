using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [HideInInspector]
    public PlayerController owner;
    public GameObject scorePopUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            owner.AddScore(100);
            Instantiate(scorePopUp, transform.position, Quaternion.identity);
        }
    }

    private void OnDestroy()
    {
        owner.DestroyBullet(this);
    }
}

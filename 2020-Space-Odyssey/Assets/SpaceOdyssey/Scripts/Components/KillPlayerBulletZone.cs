﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayerBulletZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerBullet" || collision.gameObject.tag == "EnemyBullet")
        {
            Destroy(collision.gameObject);
        }
    }
}

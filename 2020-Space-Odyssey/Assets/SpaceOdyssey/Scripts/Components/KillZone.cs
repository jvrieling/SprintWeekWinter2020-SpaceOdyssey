using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Object>().owner.RemoveEnemy(collision.gameObject.GetComponent<MoveDownScreen>());

        Destroy(collision.gameObject);
    }
}

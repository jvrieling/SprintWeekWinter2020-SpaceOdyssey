using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeOnTrigger : MonoBehaviour
{
    public GameObject explosionPrefab;

    public AudioClip audioClip;

    public AudioSource explo;

    public float explosionScale;

    public string[] collisionTags;

    private void Start()
    {
        //explo.clip = audioClip;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        foreach (string i in collisionTags)
        {
            if (i == collision.gameObject.tag)
            {
                Bullet collBullet = null;
                collBullet = collision.GetComponent<Bullet>();
                if (collBullet != null)
                {
                    collBullet.RemoveHp(1);
                }
                GameObject temp;
                if (explosionPrefab)
                {
                    temp = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                    temp.transform.localScale = new Vector3(explosionScale, explosionScale, 1);
                   
                }
                
                
                }                
                Destroy(gameObject);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public string[] collisionTags;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        foreach (string i in collisionTags)
        {
            if (i == collision.gameObject.tag)

            {
               Destroy(gameObject);
            }
        }
    }
}

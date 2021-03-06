﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour
{

    public string[] collisionTags;

    [Header("READ ONLY, DO NOT MODIFY ANY VARIABLE THROUGH INSPECTOR")]
    public float zoneBaseRadius; //The radius of the zone the moment it spawns.
    public float zoneMaxRadius; //Max zone radius

    public float zoneDuration; //Time it takes to fully reach the max radius.
    public float zoneRetainDuration; //Time it lasts after reaching max radius.
    public float zoneMaxRetainDuration;

    private SpriteRenderer sprite;

    [SerializeField]
    private new CircleCollider2D collider2D;

    private void Start()
    {
        if (!collider2D && GetComponent<CircleCollider2D>())
            collider2D = GetComponent<CircleCollider2D>();

        if (!sprite && GetComponent<SpriteRenderer>())
            sprite = GetComponent<SpriteRenderer>();

        transform.localScale = new Vector3(zoneBaseRadius, zoneBaseRadius);

        zoneMaxRetainDuration = zoneRetainDuration;
    }

    private void Update()
    {
        ExpandRadius();

        if (zoneRetainDuration <= 0)
            Destroy(gameObject);
    }

    void ExpandRadius()
    {
        if (transform.localScale.x < zoneMaxRadius)
        {
            transform.localScale += new Vector3(zoneMaxRadius / zoneDuration,
                                                zoneMaxRadius / zoneDuration) * Time.deltaTime;
        }
        else
        {
            Color tmp = sprite.color;

            //NEED TO FIND PROPER FORMULA
            tmp.a = zoneRetainDuration / zoneMaxRetainDuration;

            sprite.color = tmp;

            zoneRetainDuration -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        //REPLACE DESTROY WITH PROPER INDEX REMOVAL LATER @@@@@@@@@@@@@@@@@@
        foreach (string i in collisionTags)
        {
            if (i == other.gameObject.tag)
            {
                Destroy(other.gameObject);
            }
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/* ShootAtPlayer.cs
 * ----------------
 * Enables this ship to periodically shoot at the Player.
 * Bullet travels in a straight line with static velocity.
 */
public class ShootAtPlayer : MonoBehaviour
{
    [SerializeField]
    private float bulletVelocityMultiplier = 1;
    [SerializeField]
    private float bulletSpreadRadius = 0;

    private float currentFiringCooldown; //Time in seconds
    [SerializeField]
    private float maxFiringCooldown; //Time in seconds

    [SerializeField]
    [Range(0,1)]
    private float initialFiringCooldownMultiplier; //A ratio of the maxFiringCooldown.

    [SerializeField]
    private GameObject bulletPrefab;

    //GameObject that it will shoot at.
    private GameObject targetObject;


    void Start()
    {
        if (!bulletPrefab)
            bulletPrefab = AssetDatabase.LoadAssetAtPath("Assets/SpaceOdyssey/Prefabs/EnemyBullet.prefab",
            typeof(GameObject)) as GameObject;

        //REPLACE LATER; DONT USE TAG CHECKS
        if (!targetObject)
            targetObject = GameObject.FindGameObjectWithTag("Player");

        currentFiringCooldown = maxFiringCooldown * initialFiringCooldownMultiplier;
    }

    void Update()
    {
        if (currentFiringCooldown < maxFiringCooldown)
            currentFiringCooldown += Time.deltaTime;
        else
        {
            currentFiringCooldown = 0;

            if (targetObject != null)
                FireBullet(transform, targetObject.transform, bulletSpreadRadius);
        }

    }

    /* FireBullet()
     * ------------
     * Gets the directional vector between a start and end position,
     * and instantiates a prefab with a static velocity.
     * 
     * A higher spreadRadius decreases the accuracy of the bullets.
     */
    void FireBullet(Transform startPosition, Transform endPosition, float spreadRadius)
    {
        Vector3 direction = endPosition.position - 
                           (startPosition.position + new Vector3(Random.Range(-1f,1f) * spreadRadius, Random.Range(-1f, 1f) * spreadRadius));
        Vector3 normalizedDirection = direction.normalized;

        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity, transform);
        bullet.transform.parent = null;
        bullet.GetComponent<Rigidbody2D>().velocity = normalizedDirection * bulletVelocityMultiplier;
    }
}

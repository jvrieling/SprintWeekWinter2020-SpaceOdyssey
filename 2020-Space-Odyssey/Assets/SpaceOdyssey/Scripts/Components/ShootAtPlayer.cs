using System.Collections;
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
    private float bulletVelocityMultiplier;

    //Times are in seconds.
    [SerializeField]
    private float currentFiringCooldown, maxFiringCooldown;

    [SerializeField]
    private GameObject bulletPrefab;

    private GameObject targetObject;


    void Start()
    {
        if (!bulletPrefab)
            bulletPrefab = AssetDatabase.LoadAssetAtPath("Assets/SpaceOdyssey/Prefabs/EnemyBullet.prefab",
            typeof(GameObject)) as GameObject;

        //REPLACE LATER; DONT USE TAG CHECKS
        if (!targetObject)
            targetObject = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (currentFiringCooldown < maxFiringCooldown)
            currentFiringCooldown += Time.deltaTime;
        else
        {
            currentFiringCooldown = 0;
            FireBullet(transform, targetObject.transform);
        }

    }

    /* FireBullet()
     * ------------
     * Gets the directional vector between a start and end position,
     * and instantiates a prefab with a static velocity.
     */
    void FireBullet(Transform startPosition, Transform endPosition)
    {
        Vector3 direction = endPosition.position - startPosition.position;
        Vector3 normalizedDirection = direction.normalized;

        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity, transform);
        bullet.GetComponent<Rigidbody2D>().velocity = normalizedDirection * bulletVelocityMultiplier;
    }
}

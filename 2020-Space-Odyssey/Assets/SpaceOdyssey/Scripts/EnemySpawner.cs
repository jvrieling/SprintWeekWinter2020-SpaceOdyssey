using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float difficultyScale;

    public float enemiesPerSecond;

    public GameObject[] enemyPrefabs;

    private float timeSinceLastEnemy;
    private float timeBetweenEnemies;

    private BoxCollider2D coll;
    private Bounds collBounds;

    private void Awake()
    {
        timeBetweenEnemies = 1 / enemiesPerSecond;
        coll = GetComponent<BoxCollider2D>();
        collBounds = coll.bounds;
    }

    void Update()
    {
        timeSinceLastEnemy += Time.deltaTime;   

        if(timeSinceLastEnemy >= timeBetweenEnemies)
        {
            timeSinceLastEnemy = 0;
            Vector3 spawnPos = new Vector3(
                Random.Range(collBounds.min.x, collBounds.max.x),
                Random.Range(collBounds.min.y, collBounds.max.y),
                Random.Range(collBounds.min.z, collBounds.max.z)
            );

            MoveDownScreen tempEnemy = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], spawnPos, Quaternion.identity).GetComponent<MoveDownScreen>();
            ObjectManager.instance.RegisterEnemy(tempEnemy);
        }
    }
}

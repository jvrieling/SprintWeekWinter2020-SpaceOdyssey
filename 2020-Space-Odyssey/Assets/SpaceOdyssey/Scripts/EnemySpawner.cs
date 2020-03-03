using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float difficultyScale;

    public float enemiesPerSecond;

    public GameObject[] enemyPrefabs;
    public ObjectManager objects;

    private float timeSinceLastEnemy;
    [HideInInspector]
    public float timeBetweenEnemies;

    private BoxCollider2D coll;
    private Bounds collBounds;

    public WaveManager waveManager;
    public bool canSpawnEnemies = true;

    private void Awake()
    {
        timeBetweenEnemies = 1 / enemiesPerSecond;
        coll = GetComponent<BoxCollider2D>();
        collBounds = coll.bounds;
    }

    void Update()
    {
        timeSinceLastEnemy += Time.deltaTime;

        if (!canSpawnEnemies)
            return;

        if(timeSinceLastEnemy >= timeBetweenEnemies)
        {
            timeSinceLastEnemy = 0;

            waveManager.currentNumberOfEnemies++;

            Vector3 spawnPos = new Vector3(
                Random.Range(collBounds.min.x, collBounds.max.x),
                Random.Range(collBounds.min.y, collBounds.max.y),
                Random.Range(collBounds.min.z, collBounds.max.z)
            );

            MoveDownScreen tempEnemy = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], transform).GetComponent<MoveDownScreen>();
            tempEnemy.gameObject.transform.position = spawnPos;
            tempEnemy.gameObject.GetComponent<Object>().owner = objects;
            objects.RegisterEnemy(tempEnemy);
        }
    }
}

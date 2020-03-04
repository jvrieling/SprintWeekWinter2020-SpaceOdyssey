﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* WaveManager.cs
 * --------------
 * Controls wave-related variables, such as:
 * > Current Wave
 * > Max Enemy Count
 * 
 * Manipulates EnemySpawner.cs through:
 * > Delay between enemies
 * 
 * Requires a reference to EnemySpawner to function.
 */
public class WaveManager : MonoBehaviour
{

    public int currentWave;


    public int currentNumberOfEnemies;
    public int maxNumberOfEnemies;

    public EnemySpawner enemySpawner;

    public bool isPaused = false;


    void Update()
    {
        if (currentNumberOfEnemies >= maxNumberOfEnemies)
        {
            enemySpawner.canSpawnEnemies = false;

            StartCoroutine("SetNewWave");
        }
    }

    IEnumerator SetNewWave()
    {
        currentNumberOfEnemies = 0;


        while (isPaused)
            yield return null;
        
        float delayBeforeNextWave = 5f;


        yield return new WaitForSeconds(delayBeforeNextWave);
        
        currentWave++;

        int baseEnemyCount = 10;
        int enemiesPerWave = 5;

        maxNumberOfEnemies = baseEnemyCount + enemiesPerWave * currentWave;

        SetEnemySpawnerParameters();


        yield return null;
    }

    void SetEnemySpawnerParameters()
    {
        float baseTimeBetweenEnemies = 10f;

        enemySpawner.enemiesPerSecond = maxNumberOfEnemies;
        enemySpawner.timeBetweenEnemies = baseTimeBetweenEnemies / enemySpawner.enemiesPerSecond;

        enemySpawner.canSpawnEnemies = true;
    }
}

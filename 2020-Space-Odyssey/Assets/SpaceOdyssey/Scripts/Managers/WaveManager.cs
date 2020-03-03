using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* WaveManager.cs
 * --------------
 * 
 * 
 */
public class WaveManager : MonoBehaviour
{

    public int currentWave;


    public int currentNumberOfEnemies;
    public int maxNumberOfEnemies;

    public EnemySpawner enemySpawner;


    void Start()
    {
        
    }

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

        currentWave++;

        int baseEnemyCount = 10;
        int enemiesPerWave = 5;

        maxNumberOfEnemies = baseEnemyCount + enemiesPerWave * currentWave;

        float delayBeforeNextWave = 5f;

        yield return new WaitForSeconds(delayBeforeNextWave);

        enemySpawner.enemiesPerSecond = maxNumberOfEnemies;
        enemySpawner.timeBetweenEnemies = 10 / enemySpawner.enemiesPerSecond;

        enemySpawner.canSpawnEnemies = true;

        yield return null;
    }
}

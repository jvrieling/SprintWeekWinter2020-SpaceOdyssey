using System.Collections;
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

    
    

    public float delayBeforeNextWave = 5;

    public int baseEnemyCount = 10;
    public int enemiesPerWave = 5;

    public float baseTimeBetweenEnemies = 10;

    public EnemySpawner enemySpawner;

    public bool isPaused = false;

    [Header("READ ONLY")]
    public int currentWave;
    public int currentNumberOfEnemies;
    public int maxNumberOfEnemies;

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
        


        yield return new WaitForSeconds(delayBeforeNextWave);
        
        currentWave++;


        maxNumberOfEnemies = baseEnemyCount + enemiesPerWave * currentWave;

        SetEnemySpawnerParameters();


        yield return null;
    }

    void SetEnemySpawnerParameters()
    {

        enemySpawner.enemiesPerSecond = maxNumberOfEnemies;
        enemySpawner.timeBetweenEnemies = baseTimeBetweenEnemies / enemySpawner.enemiesPerSecond;

        enemySpawner.canSpawnEnemies = true;
    }
}

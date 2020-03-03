using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public static ObjectManager instance;

    public List<MoveDownScreen> enemies;
    public List<MoveDownScreen> bullets;
    public List<PlayerController> players;
    public List<MoveDownScreen> playerBullets;

    private void Awake()
    {
        instance = this;

        enemies = new List<MoveDownScreen>();
        bullets = new List<MoveDownScreen>();
        playerBullets = new List<MoveDownScreen>();
        players = new List<PlayerController>();
    }

    public void MultiplyEnemySpeed(float multiplier)
    {
        foreach(MoveDownScreen i in enemies)
        {
            i.UpdateMoveSpeed(i.moveSpeed * multiplier);
        }
    }

    public void RegisterEnemy(MoveDownScreen newEnemy)
    {
        if (!enemies.Contains(newEnemy))
        {
            newEnemy.UpdateMoveSpeed(newEnemy.moveSpeed * ModifierManager.instance.GetSpeedMultiplier());
            enemies.Add(newEnemy);
        }
    }  

}

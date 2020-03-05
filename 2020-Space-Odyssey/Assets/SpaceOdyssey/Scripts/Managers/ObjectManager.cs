using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    private ModifierManager modifiers;
    
    //*
    public GameObject player;

    public List<MoveDownScreen> enemies;
    public List<EnemyBullet> bullets;
    public List<PlayerBullet> playerBullets;


    private void Awake()
    {
        enemies = new List<MoveDownScreen>();
        bullets = new List<EnemyBullet>();
        playerBullets = new List<PlayerBullet>();

        modifiers = GetComponent<ModifierManager>();
    }


    public void MultiplyEnemySpeed(float multiplier)
    {
        foreach (MoveDownScreen i in enemies)
        {
            i.UpdateMoveSpeed(i.moveSpeed * multiplier);
        }
    }

    public void RegisterEnemy(MoveDownScreen newEnemy)
    {
        if (!enemies.Contains(newEnemy))
        {
            newEnemy.UpdateMoveSpeed(newEnemy.moveSpeed * modifiers.GetSpeedMultiplier());
            enemies.Add(newEnemy);
        }
    }
    public void RegisterEnemyBullet(EnemyBullet bullet)
    {
        if (!bullets.Contains(bullet))
        {
            bullets.Add(bullet);
        }
    }

    public void RemoveEnemy(MoveDownScreen enemy)
    {
        enemies.Remove(enemy);
    }
    public void RemoveEnemyBullet(EnemyBullet bullet)
    {
        bullets.Remove(bullet);
    }

    public void MultiplyPlayerSpeed(float multiplier)
    {
        float finalSpeed = player.GetComponent<ShipMotor>().baseMaxSpeed * multiplier;

        player.GetComponent<ShipMotor>().MaxSpeed = finalSpeed;
    }
}

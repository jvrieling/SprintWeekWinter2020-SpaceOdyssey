using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    private ModifierManager modifiers;

    public List<MoveDownScreen> enemies;
    public List<MoveDownScreen> bullets;
    public PlayerController player;
    public List<MoveDownScreen> playerBullets;

    private void Awake()
    {
        enemies = new List<MoveDownScreen>();
        bullets = new List<MoveDownScreen>();
        playerBullets = new List<MoveDownScreen>();       

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

    public void RemoveEnemy(MoveDownScreen enemy)
    {
        enemies.Remove(enemy);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierManager : MonoBehaviour
{
    public static ModifierManager instance;

    public bool fasterEnemies = false;
    public float speedMultiplier = 1.3f;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleFasterEnemies();
        }
    }

    public void ToggleFasterEnemies()
    {
        if (!fasterEnemies)
        {
            fasterEnemies = true;
            ObjectManager.instance.MultiplyEnemySpeed(speedMultiplier);
        } else
        {
            fasterEnemies = false;
            ObjectManager.instance.MultiplyEnemySpeed(1);
        }
    }
    public float GetSpeedMultiplier()
    {
        if (fasterEnemies)
        {
            return speedMultiplier;
        }
        return 1;
    }
}

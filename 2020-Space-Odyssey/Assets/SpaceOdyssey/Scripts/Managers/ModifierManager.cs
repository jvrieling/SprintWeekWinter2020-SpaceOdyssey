using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierManager : MonoBehaviour
{
    private ObjectManager objects;

    public bool fasterEnemies = false;
    public float speedMultiplier = 1.3f;
    public string toggleFasterEnemies = "M";

    private void Awake()
    {
        objects = GetComponent<ObjectManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(toggleFasterEnemies))
        {
            ToggleFasterEnemies();
        }
    }

    public void ToggleModifier(string mod)
    {
        switch (mod)
        {
            case "splitShot":

                break;
        }
    }

    public void ToggleFasterEnemies()
    {
        if (!fasterEnemies)
        {
            fasterEnemies = true;
           objects.MultiplyEnemySpeed(speedMultiplier);
        } else
        {
            fasterEnemies = false;
            objects.MultiplyEnemySpeed(1);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierManager : MonoBehaviour
{
    private ObjectManager objects;

    public bool fasterEnemies = false;
    public float speedMultiplier = 1.3f;
    public string toggleFasterEnemies = "M";

    //Toggle Player Movespeed Variables
    public bool fasterPlayers = false;
    public float playerSpeedMultiplier = 2f;
    public float playerSlowerSpeedMultiplier = 0.75f;
    public string toggleFasterPlayers = "n";

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
        if (Input.GetKeyDown(toggleFasterPlayers))
        {
            ToggleFasterPlayers();
        }
    }

    public void ToggleModifier(string mod)
    {
        BulletModifierManager bulMod = objects.player.GetComponent<BulletModifierManager>();
        UIManager.instance.AddModifier(objects.player.GetComponent<PlayerController>().playerNumber, mod);
        switch (mod)
        {
            case "splitShot":
                bulMod.canBulletSplit = true;                
                break;
            case "multiShot":
                bulMod.canShotgunShoot = true;
                break;
            case "increaseMoveSpeed":
                fasterPlayers = true;
                objects.MultiplyPlayerSpeed(playerSpeedMultiplier);
                break;
            case "decreaseMoveSpeed":
                fasterPlayers = true;
                objects.MultiplyPlayerSpeed(playerSlowerSpeedMultiplier);
                break;
            case "fasterEnemies":
                fasterEnemies = true;
                objects.MultiplyEnemySpeed(speedMultiplier);
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

    public void ToggleFasterPlayers()
    {
        if (!fasterPlayers)
        {
            fasterPlayers = true;
            objects.MultiplyPlayerSpeed(playerSpeedMultiplier);

        } else
        {
            fasterPlayers = false;
            objects.MultiplyPlayerSpeed(1);
        }
    }
}

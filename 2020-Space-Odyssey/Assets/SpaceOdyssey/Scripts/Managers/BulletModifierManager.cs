using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModifierManager : MonoBehaviour
{

    public PlayerController playerController;

    public bool canBulletSplit, //After x seconds, your bullets split into y by z degrees.
                canShotgunShoot; //Fire x more bullets in a cone.

    private void Start()
    {
        if (!playerController)
            playerController = GetComponent<PlayerController>();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModifierManager : MonoBehaviour
{

    public PlayerController playerController;

    public bool canBulletSplit,  //After x seconds, your bullets split into y by z degrees.
                canShotgunShoot, //Fire x more bullets in a cone.
                canSpartanLaser; //Activates ALT-FIRE for spartan laser.

    private void Start()
    {
        if (!playerController && GetComponent<PlayerController>())
            playerController = GetComponent<PlayerController>();
    }

}

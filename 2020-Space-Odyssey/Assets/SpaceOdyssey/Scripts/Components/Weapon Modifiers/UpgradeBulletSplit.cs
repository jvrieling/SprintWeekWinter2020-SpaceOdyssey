using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* UpgradeBulletSplit.cs
 * ---------------------
 * Component that enables the gameObject to destroy itself after 'x' seconds.
 * When destroyed this way, it will copy itself and instantiate 'y' copies,
 * spread evenly at 'z' degrees.
 */
public class UpgradeBulletSplit : MonoBehaviour
{
    public bool isActive;

    public float currentLifeSpan;
    public float maxLifeSpan = 1f;
    public int splitCount = 2;
    public float splitAngleInDegrees = 25f;
    public int currentGeneration;
    public int maxGenerations = 3;

    private GameObject copiedObject;


    void Update()
    {
        if (!isActive)
            return;

        if (currentLifeSpan < maxLifeSpan)
            currentLifeSpan += Time.deltaTime;
        else
        {
            SplitSelf();
        }
    }


    void SplitSelf()
    {
        currentLifeSpan = 0;
        currentGeneration++;

        copiedObject = gameObject;

        if (currentGeneration < maxGenerations)
        {
            for (int i = 0; i < splitCount; i++)
            {
                GameObject bullet = Instantiate(copiedObject, transform.position, Quaternion.identity);


                bullet.transform.Rotate(0, 0, i * (splitAngleInDegrees / (splitCount - 1)) - splitAngleInDegrees / 2);

                bullet.name = "Split Player Bullet";
            }
        }

        Destroy(gameObject);
    }
}

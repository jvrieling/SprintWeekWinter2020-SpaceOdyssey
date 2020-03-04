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

    private GameObject copiedObject;
    
    void Start()
    {

    }
    
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
        Debug.Log("Splitting!");

        currentLifeSpan = 0;

        copiedObject = gameObject;
        for (int i = 0; i < splitCount; i++)
        {
            GameObject bullet = Instantiate(copiedObject, transform.position, Quaternion.identity);


            bullet.transform.Rotate(0 , 0, (i - 0.5f) * splitAngleInDegrees);

            bullet.name = "Split Player Bullet";
        }


        Destroy(gameObject);
    }
}

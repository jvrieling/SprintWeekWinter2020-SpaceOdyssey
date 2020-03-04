using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActualSlotMachine : MonoBehaviour
{

    public Sprite[] Sprites;
    public float StopTime;

   
    void FixedUpdate()
    {
        gameObject.GetComponent<UnityEngine.UI.Image>().sprite = Sprites[Random.Range(0, Sprites.Length)];
    }

    public void EndRand()
    {
        enabled = false;
    }

    public void StartRand()
    {
        enabled = true;
    }

}

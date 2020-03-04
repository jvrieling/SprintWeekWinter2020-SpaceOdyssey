using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnModifiers : MonoBehaviour
{


    public Sprite[] Sprites;


    public void OnSpawnModifier()
    {
        enabled = true;

        gameObject.GetComponent<UnityEngine.UI.Image>().sprite = Sprites[Random.Range(0, Sprites.Length)];

    }

    public void OnModifierSelect()
    {
        enabled = false;
    }


}

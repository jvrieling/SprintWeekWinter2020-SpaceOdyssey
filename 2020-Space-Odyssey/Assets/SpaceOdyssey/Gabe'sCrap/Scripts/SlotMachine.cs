using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotMachine : MonoBehaviour
{
    public GameObject Sprite;
    public int TheNumber;

    public void RandomGenerate()
    {
        TheNumber = Random.Range(1, 11);

        Sprite.GetComponent<Text>().text = "" + TheNumber;

    }
}

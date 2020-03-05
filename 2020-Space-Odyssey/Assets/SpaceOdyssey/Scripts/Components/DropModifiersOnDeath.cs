using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropModifiersOnDeath : MonoBehaviour
{

    public GameObject[] modifierPrefabs;
    public float dropChance;

    private void OnDestroy()
    {
        float ranNum = Random.Range(0f, 1f);
        if (ranNum < dropChance)
        {
            Instantiate(modifierPrefabs[Random.Range(0, modifierPrefabs.Length)], transform.position, Quaternion.identity);
        }
    }
}

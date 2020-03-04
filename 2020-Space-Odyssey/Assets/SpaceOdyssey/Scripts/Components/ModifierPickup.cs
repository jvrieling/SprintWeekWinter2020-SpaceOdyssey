using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierPickup : MonoBehaviour
{
    public string modifierName;

    AudioSource audio;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().objectManager.GetComponent<ModifierManager>().ToggleModifier(modifierName);
            audio.Play();
            Destroy(gameObject);
        }
    }

}

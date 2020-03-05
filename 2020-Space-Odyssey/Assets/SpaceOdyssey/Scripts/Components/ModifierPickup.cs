using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierPickup : MonoBehaviour
{
    public string modifierName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().objectManager.GetComponent<ModifierManager>().ToggleModifier(modifierName);
            AudioManager.instance.Play("GainLives");
            Destroy(gameObject);
        }
    }

}

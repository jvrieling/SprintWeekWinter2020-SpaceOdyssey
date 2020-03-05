using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    private PlayerController player;
    private bool invincible;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<PlayerController>();
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        invincible = player.invincible;

        if (invincible == true)
        {
            this.spriteRenderer.enabled = true;
        }
        else if (invincible == false)
        {
            this.spriteRenderer.enabled = false;
        }
    }
}

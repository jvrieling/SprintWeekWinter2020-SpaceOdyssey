using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAim : MonoBehaviour
{private Animator shipAnim;
    public bool P1 = false;
    public bool P2 = false;
    // Start is called before the first frame update
    void Start()
    {
       shipAnim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (P1 == true)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                shipAnim.SetTrigger("Left");
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                shipAnim.SetTrigger("Right");
            }
            else
            {
                shipAnim.SetTrigger("idle");
            }
        }
        if (P2 == true)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                shipAnim.SetTrigger("Left");
            }
            else if (Input.GetKeyDown(KeyCode.G))
            {
                shipAnim.SetTrigger("Right");
            }
            else
            {
                shipAnim.SetTrigger("idle");
            }
        }
    }
}

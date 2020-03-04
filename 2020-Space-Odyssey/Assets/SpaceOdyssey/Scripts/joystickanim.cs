using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joystickanim : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    public bool P1 = false;
    public bool P2 = false;
    void Start()
    {
       animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (P1 == true)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                animator.SetTrigger("Left");
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                animator.SetTrigger("Right");
            }
        }
        else if (P2 == true)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                animator.SetTrigger("Left");
            }
            else if (Input.GetKeyDown(KeyCode.G))
            {
                animator.SetTrigger("Right");
            }
        }
    }

}

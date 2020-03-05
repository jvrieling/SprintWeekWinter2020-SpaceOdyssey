using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpartanLaser : MonoBehaviour
{
    /* Timing Notes:
     * - 3 seconds to discharge laser beam
     * - ~1 seconds to go from bottom to top of screen
     * 
     * - Visually lasts indefinitely
     */
    public string[] collisionTags;

    public float currentDuration;
    public float maxDuration = 6f;

    public Transform owner;

    public Vector3 adjustVector;

    //Test
    public bool killswitch;

    [SerializeField]
    private Animator animator;

    public GameObject scorePopUp;





    void Start()
    {
        if (!animator && GetComponent<Animator>())
            animator = GetComponent<Animator>();
    }



    void Update()
    {
        if (currentDuration < maxDuration)
        {
            currentDuration += Time.deltaTime;
        } else
        {
            DestroySelf();
        }

        if (killswitch)
            DestroySelf();

        FollowOwner();
        CheckForDeadOwner();
    }
    


    void DestroySelf()
    {
        Destroy(transform.parent.gameObject);
    }


    void FollowOwner()
    {
        if (owner)
        {
            Debug.Log("Following Player");
            transform.parent.position = owner.position + adjustVector;
        }
    }

    void CheckForDeadOwner()
    {
        if (!owner)
            return;

        if (owner.gameObject.GetComponent<PlayerController>().isDead)
            DestroySelf();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        //REPLACE DESTROY WITH PROPER INDEX REMOVAL LATER @@@@@@@@@@@@@@@@@@
        foreach (string i in collisionTags)
        {
            if (i == other.gameObject.tag)
            {
                owner.gameObject.GetComponent<PlayerController>().AddScore(100);
                Instantiate(scorePopUp, other.transform.position, Quaternion.identity);
                Destroy(other.gameObject);
            }
        }
    }
}

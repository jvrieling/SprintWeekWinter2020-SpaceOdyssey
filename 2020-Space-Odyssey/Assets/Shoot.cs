using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource pewpew;
    // Start is called before the first frame update
    void Start()
    {
        pewpew.clip = audioClip;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            pewpew.PlayOneShot(audioClip);
        }
    }
}

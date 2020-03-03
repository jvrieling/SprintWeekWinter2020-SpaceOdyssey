using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
      
    private AudioSource audioSource;
    public AudioClip[] shoot;
    private AudioClip shootClip;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int index = Random.Range(0, shoot.Length);
            shootClip = shoot[index];

            audioSource.clip = shootClip;
            audioSource.Play();
        }
    }
}



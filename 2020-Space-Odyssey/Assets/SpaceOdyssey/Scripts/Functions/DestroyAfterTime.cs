using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float timeToDestroy = 0f;
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        //audioSource.pitch = Random.Range(0.5f, 1f);
        AudioManager.instance.Play("PlayerDeath");

    }
    void Update()
    {
        if(timeToDestroy <= 0)
        {
            Destroy(gameObject);
        }
        timeToDestroy -= Time.deltaTime; 
    }
}

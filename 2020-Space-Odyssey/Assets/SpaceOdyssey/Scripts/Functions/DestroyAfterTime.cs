using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float timeToDestroy = 0f;
    
    private void Start()
    {
        

    }
    void Update()
    {
        
        if (timeToDestroy <= 0)
        {
            
            Destroy(gameObject);
        }
        timeToDestroy -= Time.deltaTime; 
    }
}

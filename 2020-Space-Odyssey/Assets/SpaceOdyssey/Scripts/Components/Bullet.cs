using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int hp = 1;

    public void RemoveHp(int amt)
    {
        hp -= 1;
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}

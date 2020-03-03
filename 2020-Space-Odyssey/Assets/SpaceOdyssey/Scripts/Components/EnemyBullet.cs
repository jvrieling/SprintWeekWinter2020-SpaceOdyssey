using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private void OnDestroy()
    {
        GetComponent<Object>().owner.RemoveEnemyBullet(this);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public PlayerController owner;
    private void OnDestroy()
    {
        owner.DestroyBullet(this);
    }
}

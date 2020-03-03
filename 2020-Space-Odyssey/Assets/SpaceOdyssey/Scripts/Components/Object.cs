using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public ObjectManager owner;
    public string objectType;

    private void OnDestroy()
    {
        if(objectType == "enemy")
        {
            owner.RemoveEnemy(GetComponent<MoveDownScreen>());
        }
    }
}

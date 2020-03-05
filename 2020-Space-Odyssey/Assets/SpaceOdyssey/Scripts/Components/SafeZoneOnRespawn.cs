using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SafeZoneOnRespawn : MonoBehaviour
{
    public float zoneBaseRadius; //The radius of the zone the moment it spawns.
    public float zoneMaxRadius; //Max zone radius

    public float zoneDuration; //Time it takes to fully reach the max radius.
    public float zoneRetainDuration; //Time it lasts after reaching max radius.

    [Header("READ ONLY")]
    [SerializeField]
    private PlayerController playerController;
    [SerializeField]
    private GameObject safeZonePrefab;

    private void Start()
    {
        if (!playerController && GetComponent<PlayerController>())
            playerController = GetComponent<PlayerController>();

        if (!safeZonePrefab)
        {
            safeZonePrefab = AssetDatabase.LoadAssetAtPath("Assets/SpaceOdyssey/Prefabs/Safe Zone.prefab",
            typeof(GameObject)) as GameObject;
        }

    }

    /* ActivateSafeZone()
     * ------------------
     * Instantiates the prefab that does the thing.
     * 
     * Sets the prefab values from this function with the reference to it
     */
    public void ActivateSafeZone()
    {
        Debug.Log("Spawned a SAFE ZONE!");
        GameObject prefab = Instantiate(safeZonePrefab, transform);
        prefab.transform.parent = null;

        SafeZone safeZone = prefab.GetComponent<SafeZone>();

        safeZone.zoneBaseRadius = zoneBaseRadius;
        safeZone.zoneMaxRadius = zoneMaxRadius;
        safeZone.zoneDuration = zoneDuration;
        safeZone.zoneRetainDuration = zoneRetainDuration;
    }
    
}

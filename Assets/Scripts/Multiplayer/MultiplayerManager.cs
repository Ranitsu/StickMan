using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MultiplayerManager : MonoBehaviour
{
    public Transform mapObject;
    public List<Transform> respawns = new List<Transform>();
    //public List<Transform> enemyRespawns = new List<Transform>();
    //public GameObject enemyPrefab;

    public float timeBetweenSpawnEnemy;

    void Awake()
    {
        mapObject = GameObject.Find("Map").transform;

        Transform respawnsObject = mapObject.Find("Respawns");
        Transform[] tempRes = respawnsObject.GetComponentsInChildren<Transform>();

        foreach (Transform tr in tempRes)
            if (tr.name != "Respawns")
                respawns.Add(tr);

        /*respawnsObject = mapObject.Find("EnemyRespawns");
        tempRes = respawnsObject.GetComponentsInChildren<Transform>();

        foreach (Transform tr in tempRes)
            if (tr.name != "EnemyRespawns")
                enemyRespawns.Add(tr);
        */
    }
}

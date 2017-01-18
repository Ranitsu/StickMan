using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public Transform mapObject;
    public GameObject leftBorder;
    public GameObject rightBorder;
    public GameObject topBorder;
    public GameObject bottomBorder;

    public float mapSizeX;
    public float mapSizeY;
    public float mapScale = 1f;

    public List<Transform> respawns = new List<Transform>();
    public List<Transform> enemyRespawns = new List<Transform>();

    public GameObject enemyPrefab;
    public float timeBetweenSpawnEnemy;

    public enum typeOfGame
    {
        single,
        defense,
        multi
    }

    public typeOfGame typGry;

    void Awake()
    {
        mapObject = GameObject.Find("Map").transform;
        leftBorder = GameObject.Find("LeftBorder");
        rightBorder = GameObject.Find("RightBorder");
        topBorder = GameObject.Find("TopBorder");
        bottomBorder = GameObject.Find("BottomBorder");

        leftBorder.GetComponent<BoxCollider2D>().size = new Vector2(1, mapSizeY);
        rightBorder.GetComponent<BoxCollider2D>().size = new Vector2(1, mapSizeY);
        topBorder.GetComponent<BoxCollider2D>().size = new Vector2(mapSizeX, 1);
        bottomBorder.GetComponent<BoxCollider2D>().size = new Vector2(mapSizeX, 1);

        leftBorder.GetComponent<BoxCollider2D>().offset = new Vector2(-0.5f, mapSizeY/2);
        rightBorder.GetComponent<BoxCollider2D>().offset = new Vector2(mapSizeX + 0.5f, mapSizeY/2);
        topBorder.GetComponent<BoxCollider2D>().offset = new Vector2(mapSizeX/2, mapSizeY + 0.5f);
        bottomBorder.GetComponent<BoxCollider2D>().offset = new Vector2(mapSizeX/2, -0.5f);

        Transform respawnsObject = mapObject.Find("Respawns");
        Transform[] tempRes = respawnsObject.GetComponentsInChildren<Transform>();

        foreach (Transform tr in tempRes)
            if(tr.name != "Respawns")
                respawns.Add(tr);

        respawnsObject = mapObject.Find("EnemyRespawns");
        tempRes = respawnsObject.GetComponentsInChildren<Transform>();

        foreach (Transform tr in tempRes)
            if (tr.name != "EnemyRespawns")
                enemyRespawns.Add(tr);
    }

	void Start ()
    {
        //SpawnEnemy();
        InvokeRepeating("SpawnEnemy", 0, timeBetweenSpawnEnemy);
    }
	
	void Update ()
    {
        //InvokeRepeating("SpawnEnemy", 0,timeBetweenSpawnEnemy);
    }

    void SpawnEnemy()
    {
        Transform respawn = enemyRespawns[Random.Range(0, enemyRespawns.Count)];
        GameObject enemy = Instantiate(enemyPrefab, respawn.position, respawn.rotation) as GameObject;
    }
}

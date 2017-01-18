using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{
    public GameObject target;
    public GameObject gameManager;

    public float smooth = 1f;

    float mapSizeX;
    float mapSizeY;

    float minX;
    float maxX;
    float minY;
    float maxY;

    Vector3 followerVelocity;

    void Start ()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController");
        target = GameObject.FindGameObjectWithTag("Player");
        mapSizeX = gameManager.GetComponent<GameManager>().mapSizeX;
        mapSizeY = gameManager.GetComponent<GameManager>().mapSizeY;

        float vertExtent = Camera.main.orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;

        minX = horzExtent;
        maxX = mapSizeX - horzExtent;
        minY = vertExtent;
        maxY = mapSizeY - vertExtent;
    }

    void FixedUpdate()
    {
        Vector3 v2 = target.transform.position;
        v2.x = Mathf.Clamp(v2.x, minX, maxX);
        v2.y = Mathf.Clamp(v2.y, minY, maxY);
        v2.z = -2;
        transform.position = Vector3.SmoothDamp(transform.position, v2, ref followerVelocity, smooth);
        //transform.position = v2;
    }
}
